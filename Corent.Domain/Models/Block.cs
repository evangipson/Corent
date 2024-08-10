namespace Corent.Domain.Models
{
    /// <summary>
    /// A block of transactions.
    /// </summary>
    public class Block
    {
        /// <summary>
        /// A unique collection of Corent <see cref="Transaction">Transactions</see>.
        /// </summary>
        public ISet<Transaction> Transactions { get; set; } = new HashSet<Transaction>();

        /// <summary>
        /// The previous transaction block's hash.
        /// </summary>
        public byte[]? PreviousBlockHash { get; set; }

        /// <summary>
        /// The next transaction block's hash.
        /// </summary>
        public byte[]? NextBlockHash { get; set; }

        /// <summary>
        /// A block's hash.
        /// </summary>
        public byte[]? Hash { get; set; }
    }
}
