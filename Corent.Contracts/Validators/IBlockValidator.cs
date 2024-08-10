using Corent.Domain.Models;

namespace Corent.Contracts.Validators
{
    /// <summary>
    /// A validator responsible for validating a <see cref="Block"/>.
    /// <para>
    /// Intended to be invoked by many distributed nodes.
    /// </para>
    /// </summary>
    public interface IBlockValidator : IValidator<Block>
    {
    }
}
