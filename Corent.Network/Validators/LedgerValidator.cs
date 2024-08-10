using Corent.Base.Attributes;
using Corent.Contracts.Validators;
using Corent.Domain.Models;

namespace Corent.Network.Validators
{
    /// <inheritdoc cref="ILedgerValidator"/>
    [Service(typeof(ILedgerValidator))]
    public class LedgerValidator : ILedgerValidator
    {
        public Task<bool> TryValidate(Ledger ledger, out bool validity)
        {
            validity = false;
            return Task.Run(() => false);
        }
    }
}
