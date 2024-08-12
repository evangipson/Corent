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
        /// <param name="blockHash">
        /// A hash used to confirm the <see cref="Ledger"/> is up to date.
        /// </param>
        /// <param name="ledger">
        /// The discovered <see cref="Ledger"/>, defaults to <c>null</c>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> which contains the success status of
        /// the look up.
        /// </returns>
        Task<bool> TryGetLedger(byte[] blockHash, out Ledger? ledger);
    }
}
