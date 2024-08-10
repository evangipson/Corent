namespace Corent.Domain.Models
{
    /// <summary>
    /// A transaction of Corent.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// The sender of the transaction.
        /// </summary>
        public Wallet? Sender { get; set; }

        /// <summary>
        /// The recipient of the transaction.
        /// </summary>
        public Wallet? Recipient { get; set; }

        /// <summary>
        /// The amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The time of the transaction creation.
        /// </summary>
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// The time of the transaction fulfillment.
        /// </summary>
        public DateTime FulfilledTime { get; set; }
    }
}
