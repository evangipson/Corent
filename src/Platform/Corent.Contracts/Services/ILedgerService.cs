using Corent.Domain.Models;

namespace Corent.Contracts.Services
{
    /// <summary>
    /// A service to interact with the <see cref="Ledger"/>.
    /// </summary>
    public interface ILedgerService : IMicroservice, IMessageService
    {
        /// <summary>
        /// Attempts to add a <see cref="Block"/> to the <see cref="Ledger"/>.
        /// </summary>
        /// <param name="block">
        /// The <see cref="Block"/> to add on the <see cref="Ledger"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> which contains the success status of
        /// the addition.
        /// </returns>
        Task<bool> TryAddBlock(Block? block);

        /// <summary>
        /// Attempts to get the <see cref="Ledger"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="Task"/> which contains the ledger.
        /// </returns>
        Task<Ledger> TryGetLedger();
    }
}
