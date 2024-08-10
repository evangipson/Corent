using Corent.Domain.Models;

namespace Corent.Contracts.Services
{
    /// <summary>
    /// A service to interact with a <see cref="Wallet"/>.
    /// </summary>
    public interface IWalletService
    {
        /// <summary>
        /// Attempts a transfer between the <paramref name="sender"/>
        /// and <paramref name="receiver"/>.
        /// </summary>
        /// <param name="sender">
        /// The sender of the transfer.
        /// </param>
        /// <param name="receiver">
        /// The receiver of the transfer.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> which contains the success status of
        /// the transfer.
        /// </returns>
        Task<bool> TryTransfer(Wallet sender, Wallet receiver);

        /// <summary>
        /// Attempts to get a wallet by <paramref name="address"/>.
        /// </summary>
        /// <param name="address">
        /// A <see cref="Guid"/> used to look up the <see cref="Wallet"/>.
        /// </param>
        /// <param name="wallet">
        /// The discovered <see cref="Wallet"/>, defaults to <c>null</c>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> which contains the success status of
        /// the <see cref="Wallet"/> look up.
        /// </returns>
        Task<bool> TryGetWallet(Guid address, out Wallet? wallet);

        /// <summary>
        /// Attempts to get a wallet by <paramref name="secret"/>.
        /// </summary>
        /// <param name="secret">
        /// A hashed array of <see cref="byte"/> used to look up
        /// the <see cref="Wallet"/>.
        /// </param>
        /// <param name="wallet">
        /// The discovered <see cref="Wallet"/>, defaults to <c>null</c>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> which contains the success status of
        /// the <see cref="Wallet"/> look up.
        /// </returns>
        Task<bool> TryGetWallet(byte[] secret, out Wallet? wallet);
    }
}
