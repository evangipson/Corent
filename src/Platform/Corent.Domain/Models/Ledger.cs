namespace Corent.Domain.Models
{
    /// <summary>
    /// The total collection of <see cref="Transaction"/> <see cref="Block">Blocks</see>.
    /// </summary>
    public class Ledger
    {
        /// <summary>
        /// The latest <see cref="Block"/> in the chain.
        /// </summary>
        public Block? LatestBlock { get; set; }
    }
}
