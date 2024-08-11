using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using Corent.Contracts.Services;

namespace Corent.Logic.Services
{
    /// <inheritdoc cref="IMessageService"/>
    public abstract class MessageService(
        ILogger<MessageService> logger,
        ISerializationService serializationService,
        IConnectionFactory connectionFactory) : IMessageService
    {
        private readonly ILogger<MessageService> _logger = logger;
        private readonly ISerializationService _serializationService = serializationService;

        private IConnection? _connection;
        private IModel? _channel;
        private bool _disposed = false;

        protected IConnection Connection
        {
            get
            {
                if (connectionFactory == null)
                {
                    throw new ApplicationException("Could not create connection factory for creating the message service connection.");
                }

                return _connection ??= connectionFactory.CreateConnection(["message-bus", "localhost"]);
            }
        }

        protected IModel Channel
        {
            get
            {
                if (Connection == null)
                {
                    throw new ApplicationException("Could not create connection model because connection was null.");
                }

                return _channel ??= Connection.CreateModel();
            }
        }

        protected abstract string QueueName { get; }

        public virtual void ConsumeMessages()
        {
            EventingBasicConsumer channel = new(Channel);
            CreateQueue();
            channel.Received += MessageReceivedCallback;
            _logger.LogInformation($"{nameof(ConsumeMessages)}: Consuming messages.");
            Channel.BasicConsume(QueueName, true, channel);

            // TODO: There has gotta be a better way to do this.
            while (Channel.CloseReason == null)
            {
                Thread.Sleep(5000);
            }

            _logger.LogInformation($"{nameof(ConsumeMessages)}: Closing channel due to {Channel.CloseReason}.");
            CloseConnection();
        }

        public virtual void PublishMessage<MessageType>(MessageType message)
        {
            CreateQueue();
            byte[] serializedBytes = _serializationService.Serialize(message);
            _logger.LogInformation($"{nameof(PublishMessage)}: Publishing message \"{Encoding.UTF8.GetString(serializedBytes)}\".");
            Channel.BasicPublish(string.Empty, QueueName, null, serializedBytes);
        }

        public virtual void MessageReceivedCallback(object? model, BasicDeliverEventArgs eventArgs)
        {
            var message = Encoding.UTF8.GetString(eventArgs.Body.ToArray());
            _logger.LogInformation($"{nameof(MessageReceivedCallback)}: [x] Message received \"{message}\".");
        }

        private void CreateQueue()
        {
            Channel.ExchangeDeclare("call_notify", "fanout");
            Channel.QueueDeclare(QueueName, true, false, false, null);
            Channel.QueueBind(QueueName, "call_notify", "");
        }

        private void CloseConnection()
        {
            Channel.Abort();
            Connection.Abort();

            _channel = null;
            _connection = null;
        }
    }
}
