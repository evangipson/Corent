using System.Net.Sockets;

namespace Corent.Domain.Models
{
    /// <summary>
    /// A node within the Corent network.
    /// </summary>
    public class CorentNode
    {
        /// <summary>
        /// A listener for incoming node connections.
        /// </summary>
        public TcpListener? Listener { get; set; }

        /// <summary>
        /// A list of clients that are listening to this node.
        /// </summary>
        public List<TcpClient> Clients { get; set; } = [];
    }
}
