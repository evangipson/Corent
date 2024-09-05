using System.Net;
using System.Net.Sockets;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using Corent.Base.Attributes;
using Corent.Contracts.Services;
using Corent.Domain.Constants;
using Corent.Domain.Models;
using Corent.Domain.Options;
using Corent.Logic.Services;

namespace Corent.Network.Services
{
    [Service(typeof(INetworkService))]
    public class NetworkService : MessageService, INetworkService
    {
        private readonly ILogger<NetworkService> _logger;
        private readonly IOptions<CorentNetwork> _options;
        private readonly ISerializationService _serializationService;
        private readonly ILedgerService _ledgerService;
        private readonly CorentNode _corentNode = new();

        protected override string QueueName => MessagingConstants.NetworkQueue;

        public NetworkService(ILogger<NetworkService> logger,
            IOptions<CorentNetwork> options,
            ISerializationService serializationService,
            IConnectionFactory connectionFactory,
            ILedgerService ledgerService) : base(logger, serializationService, connectionFactory)
        {
            _logger = logger;
            _options = options;
            _serializationService = serializationService;
            _ledgerService = ledgerService;
        }

        public void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Network microservice started.");

            if(_options.Value.Port == default)
            {
                _logger.LogError($"{nameof(Run)}: Failed to get port from application settings.");
                return;
            }

            _corentNode.Listener = new TcpListener(IPAddress.Any, _options.Value.Port);
            _corentNode.HostName = _corentNode.Listener.LocalEndpoint.ToString()?.Split(":").First() ?? string.Empty;
            _corentNode.Port = _options.Value.Port;
            _logger.LogInformation($"{nameof(Run)}: Set node endpoint to {_corentNode.HostName}:{_corentNode.Port}.");

            _corentNode.Listener.Start();
            _logger.LogInformation($"{nameof(Run)}: Network microservice listener started at {_corentNode.Listener.LocalEndpoint}.");

            var hostNameAndPort = new KeyValuePair<string, int>(_corentNode.HostName, _corentNode.Port);
            if (_corentNode.Port == 5209)
            {
                ConsumeMessages();
            }
            else
            {
                PublishMessage(hostNameAndPort);
            }
        }

        public override void MessageReceivedCallback(object? model, BasicDeliverEventArgs eventArgs)
        {
            var hostNameAndPort = _serializationService.Deserialize<KeyValuePair<string, int>>(eventArgs.Body.ToArray());
            if(_corentNode.HostName != hostNameAndPort.Key && _corentNode.Port != hostNameAndPort.Value)
            {
                _logger.LogInformation($"{nameof(MessageReceivedCallback)}: [x] Message received \"{hostNameAndPort}\".");

                ConnectToClient(hostNameAndPort.Key, hostNameAndPort.Value);
                BroadcastMessage("Hello from the other networking node!");
            }
        }

        public void ConnectToClient(string hostName, int port)
        {
            _corentNode.Clients.Add(new TcpClient(hostName, port));
            _logger.LogInformation($"{nameof(ConnectToClient)}: Network microservice client connected at {hostName}:{port}.");
            _logger.LogInformation($"{nameof(ConnectToClient)}: Total client list\n{string.Join(", ", _corentNode.Clients.Select(client => client.Client.AddressFamily))}");
        }

        public void BroadcastMessage(string message)
        {
            foreach (var client in _corentNode.Clients)
            {
                var stream = client.GetStream();
                var data = Encoding.UTF8.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
    }
}
