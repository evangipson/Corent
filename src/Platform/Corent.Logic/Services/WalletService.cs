using Microsoft.Extensions.Logging;

using Corent.Base.Attributes;
using Corent.Contracts.Services;
using Corent.Domain.Models;

namespace Corent.Logic.Services
{
    /// <inheritdoc cref="IWalletService"/>
    [Service(typeof(IWalletService))]
    public class WalletService(ILogger<WalletService> logger) : IWalletService
    {
        private readonly ILogger<WalletService> _logger = logger;

        public void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Wallet microservice started.");
        }

        public Task<bool> TryTransfer(Wallet sender, Wallet receiver)
        {
            // TODO: broadcast message when transfer is successful
            // so it can be added to the latest block
            return Task.Run(() => false);
        }

        public Task<bool> TryGetWallet(Guid address, out Wallet? wallet)
        {
            // TODO: look up wallet from the Ledger
            wallet = null;
            return Task.Run(() =>
            {
                return false;
            });
        }

        public Task<bool> TryGetWallet(byte[] secret, out Wallet? wallet)
        {
            // TODO: look up wallet from the Ledger
            wallet = null;
            return Task.Run(() =>
            {
                return false;
            });
        }
    }
}
