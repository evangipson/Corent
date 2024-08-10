using Corent.Domain.Models;

namespace Corent.Contracts.Validators
{
    /// <summary>
    /// A validator responsible for validating a <see cref="Ledger"/>.
    /// <para>
    /// Intended to be invoked by many distributed nodes.
    /// </para>
    /// </summary>
    public interface ILedgerValidator : IValidator<Ledger>
    {
    }
}
