using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

using Corent.Base.Attributes;
using Corent.Contracts.Services;
using Corent.Domain.Constants;
using Corent.Domain.Models;

namespace Corent.Logic.Services
{
    /// <inheritdoc cref="IWalletService"/>
    [Service(typeof(IWalletService))]
    public class WalletService(
        ILogger<WalletService> logger,
        ISerializationService serializationService,
        IConnectionFactory connectionFactory) : MessageService(logger, serializationService, connectionFactory), IWalletService
    {
        private readonly ILogger<WalletService> _logger = logger;

        protected override string QueueName => MessagingConstants.WalletQueue;

        public void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Wallet microservice started.");

            ConsumeMessages();
        }

        public override void MessageReceivedCallback(object? model, BasicDeliverEventArgs eventArgs)
        {
            // TODO: Define what to do when receiving a message... probably invoke the methods below?
            base.MessageReceivedCallback(model, eventArgs);
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
