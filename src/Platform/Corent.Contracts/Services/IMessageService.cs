using Microsoft.Extensions.Hosting;
using RabbitMQ.Client.Events;

namespace Corent.Contracts.Services
{
    /// <summary>
    /// A service that will send and receive messages.
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Consumes messages from a message bus.
        /// </summary>
        void ConsumeMessages();

        /// <summary>
        /// Publishes a <typeparamref name="MessageType"/> message.
        /// </summary>
        /// <typeparam name="MessageType">
        /// The type of message to publish.
        /// </typeparam>
        /// <param name="message">
        /// The <typeparamref name="MessageType"/> message to publish.
        /// </param>
        void PublishMessage<MessageType>(MessageType message);

        /// <summary>
        /// Runs when a message is received.
        /// </summary>
        /// <param name="model"></param>
        /// <param name="eventArgs"></param>
        void MessageReceivedCallback(object? model, BasicDeliverEventArgs eventArgs);
    }
}
