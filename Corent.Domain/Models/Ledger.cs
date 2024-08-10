namespace Corent.Domain.Models
{
    /// <summary>
    /// The total collection of <see cref="Transaction"/> <see cref="Block">Blocks</see>.
    /// </summary>
    public class Ledger
    {
        /// <summary>
        /// A unique collection of <see cref="Transaction"/> <see cref="Block">Blocks</see>.
        /// </summary>
        public ISet<Block> Blocks { get; set; } = new HashSet<Block>();
    }
}
