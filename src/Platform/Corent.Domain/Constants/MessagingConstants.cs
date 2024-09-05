using Corent.Domain.Models;

namespace Corent.Domain.Constants
{
    /// <summary>
    /// A collection of constant values for the messaging service.
    /// </summary>
    public static class MessagingConstants
    {
        /// <summary>
        /// The name of the <see cref="Wallet"/> queue.
        /// </summary>
        public const string WalletQueue = "wallet-queue";

        /// <summary>
        /// The name of the <see cref="Ledger"/> queue.
        /// </summary>
        public const string LedgerQueue = "ledger-queue";

        /// <summary>
        /// The name of the Network queue.
        /// </summary>
        public const string NetworkQueue = "network-queue";
    }
}
