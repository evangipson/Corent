using Microsoft.Extensions.Logging;

using Corent.Base.Attributes;
using Corent.Contracts.Services;

namespace Corent.Wallet.Console.Controllers
{
    /// <summary>
    /// A basic implementation of <see cref="IMicroservice"/>
    /// that will log a message upon initialization.
    /// </summary>
    /// <param name="logger"></param>
    [Service(typeof(IMicroservice))]
    public class ApplicationController(ILogger<ApplicationController> logger) : IMicroservice
    {
        private readonly ILogger<ApplicationController> _logger = logger;

        public void Run()
        {
            _logger.LogInformation($"{nameof(Run)}: Started application.");
        }
    }
}
