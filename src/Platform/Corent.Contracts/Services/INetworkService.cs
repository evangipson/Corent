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
        /// Listens for incoming <see cref="CorentNode"/> connections.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> which listens for clients.
        /// </returns>
        void ListenForClientsAsync();

        /// <summary>
        /// Broadcasts a message to all clients of a <see cref="CorentNode"/>.
        /// </summary>
        /// <param name="message">
        /// The message to broadcast.
        /// </param>
        void BroadcastMessage(string message);
    }
}
