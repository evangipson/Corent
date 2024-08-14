using System.Net;
using System.Net.Sockets;
using System.Text;

using Corent.Base.Attributes;
using Corent.Contracts.Services;
using Corent.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Corent.Network.Services
{
    [Service(typeof(INetworkService))]
    public class NetworkService(ILogger<NetworkService> logger) : INetworkService
    {
        private readonly ILogger<NetworkService> _logger = logger;
        private readonly CorentNode _corentNode = new();
        private readonly int _port = 5209;

        public void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Network microservice started.");

            _corentNode.Listener = new TcpListener(IPAddress.Any, _port);
            _corentNode.Listener.Start();
            _logger.LogInformation($"{nameof(Run)}: Network microservice listener started at {_corentNode.Listener.LocalEndpoint}.");
            ListenForClientsAsync();
        }

        public void ListenForClientsAsync()
        {
            while (_corentNode.Listener != null)
            {
                var client = _corentNode.Listener.AcceptTcpClient();
                _corentNode.Clients.Add(client);
                _logger.LogInformation($"{nameof(Run)}: Network microservice client connected at {client.Client.AddressFamily}.");
            }
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
