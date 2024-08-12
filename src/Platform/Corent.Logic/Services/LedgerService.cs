using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

using Corent.Base.Attributes;
using Corent.Contracts.Services;
using Corent.Domain.Constants;
using Corent.Domain.Models;

namespace Corent.Logic.Services
{
    /// <inheritdoc cref="ILedgerService"/>
    [Service(typeof(ILedgerService))]
    public class LedgerService(
        ILogger<LedgerService> logger,
        ISerializationService serializationService,
        IConnectionFactory connectionFactory) : MessageService(logger, serializationService, connectionFactory), ILedgerService
    {
        private readonly ILogger<LedgerService> _logger = logger;

        protected override string QueueName => MessagingConstants.LedgerQueue;

        public void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Ledger microservice started.");

            ConsumeMessages();
        }

        public Task<bool> TryAddBlock(Block? block)
        {
            return Task.Run(() =>
            {
                return false;
            });
        }

        public Task<bool> TryGetLedger(byte[] blockHash, out Ledger? ledger)
        {
            ledger = null;
            return Task.Run(() =>
            {
                return false;
            });
        }
    }
}
