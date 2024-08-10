namespace Corent.Domain.Models
{
    /// <summary>
    /// A wallet to hold Corent.
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// The amount of Corent in a wallet.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// The address of a Corent wallet.
        /// </summary>
        public Guid Address { get; set; }

        /// <summary>
        /// The secret of a Corent wallet, only
        /// known by the owner.
        /// </summary>
        public byte[]? Secret { get; set; }
    }
}
