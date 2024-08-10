using Corent.Base.Attributes;
using Corent.Contracts.Validators;
using Corent.Domain.Models;

namespace Corent.Network.Validators
{
    /// <inheritdoc cref="IBlockValidator"/>
    [Service(typeof(IBlockValidator))]
    public class BlockValidator : IBlockValidator
    {
        public Task<bool> TryValidate(Block block, out bool validity)
        {
            validity = false;
            return Task.Run(() => false);
        }
    }
}
