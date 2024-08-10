using Corent.Domain.Models;

namespace Corent.Logic.Builders
{
    /// <summary>
    /// Creates a new <see cref="Wallet"/>.
    /// </summary>
    public class WalletBuilder
    {
        private readonly Wallet _wallet = new();

        /// <summary>
        /// Creates a new <see cref="WalletBuilder"/>.
        /// </summary>
        /// <returns>
        /// A new <see cref="WalletBuilder"/>.
        /// </returns>
        public static WalletBuilder Create()
        {
            return new();
        }

        /// <summary>
        /// Adds the <paramref name="amount"/> to the
        /// <see cref="Wallet"/> being created.
        /// </summary>
        /// <param name="amount">
        /// The initial amount to add to the wallet.
        /// </param>
        /// <returns>
        /// The <see cref="WalletBuilder"/> instance.
        /// </returns>
        public WalletBuilder Add(decimal amount)
        {
            _wallet.Amount = amount;
            return this;
        }

        /// <summary>
        /// Adds the <paramref name="address"/> to the
        /// <see cref="Wallet"/> being created.
        /// </summary>
        /// <param name="address">
        /// The address to add to the wallet.
        /// </param>
        /// <returns>
        /// The <see cref="WalletBuilder"/> instance.
        /// </returns>
        public WalletBuilder Add(Guid address)
        {
            _wallet.Address = address;
            return this;
        }

        /// <summary>
        /// Provides a secret hash for the <see cref="Wallet"/>,
        /// and returns it.
        /// </summary>
        /// <returns></returns>
        public Wallet Build()
        {
            // TODO: add encryption service for generating wallet hash
            _wallet.Secret = [];

            return _wallet;
        }
    }
}
