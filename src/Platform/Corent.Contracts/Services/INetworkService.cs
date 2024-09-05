using Corent.Domain.Models;

namespace Corent.Contracts.Services
{
    /// <summary>
    /// A service responsible for connecting a <see cref="CorentNode"/>
    /// to one or many <see cref="CorentNode"/>.
    /// </summary>
    public interface INetworkService : IMicroservice
    {
        /// <summary>
        /// Connects to another <see cref="CorentNode"/>.
        /// </summary>
        void ConnectToClient(string hostName, int port);

        /// <summary>
        /// Broadcasts a message to all clients of a <see cref="CorentNode"/>.
        /// </summary>
        /// <param name="message">
        /// The message to broadcast.
        /// </param>
        void BroadcastMessage(string message);
    }
}
