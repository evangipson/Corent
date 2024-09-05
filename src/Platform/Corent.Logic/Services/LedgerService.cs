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
    public class LedgerService : MessageService, ILedgerService
    {
        private readonly ILogger<LedgerService> _logger;
        private readonly Block _genesisBlock = new()
        {
            Hash = [Byte.MinValue],
            Transactions = new HashSet<Transaction>(),
        };

        private Ledger _ledger = new();

        protected override string QueueName => MessagingConstants.LedgerQueue;

        public LedgerService(ILogger<LedgerService> logger, ISerializationService serializationService, IConnectionFactory connectionFactory)
            : base(logger, serializationService, connectionFactory)
        {
            _logger = logger;
        }

        public async void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Ledger microservice started.");

            _ledger = await InitializeLedger();
            _logger.LogInformation($"{nameof(Run)}: Ledger created.\n{_ledger}");

            ConsumeMessages();
        }

        public Task<bool> TryAddBlock(Block? block)
        {
            _ledger.LatestBlock = block;
            return Task.FromResult(true);
        }

        public Task<Ledger> TryGetLedger()
        {
            return Task.FromResult(_ledger);
        }

        private async Task<Ledger> InitializeLedger()
        {
            if (_ledger.LatestBlock == _genesisBlock)
            {
                _logger.LogInformation($"{nameof(InitializeLedger)}: Ledger already has blocks, so no need to add genesis block.");
                return _ledger;
            }

            var addedGenesisBlock = await TryAddBlock(_genesisBlock);
            if (!addedGenesisBlock)
            {
                _logger.LogError($"{nameof(InitializeLedger)}: Creation of genesis block failed.");
            }

            return _ledger;
        }
    }
}
