using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;

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

        public string? HostName { get; set; }

        public int Port { get; set; }

        /// <summary>
        /// A list of clients that are listening to this node.
        /// </summary>
        public List<TcpClient> Clients { get; set; } = [];
    }
}
