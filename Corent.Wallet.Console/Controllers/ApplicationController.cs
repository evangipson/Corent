using Microsoft.Extensions.Logging;

using Corent.Base.Attributes;
using Corent.Wallet.Console.Controllers.Interfaces;

namespace Corent.Wallet.Console.Controllers
{
    /// <inheritdoc cref="IApplicationController" />
    [Service(typeof(IApplicationController))]
    public class ApplicationController(ILogger<ApplicationController> logger) : IApplicationController
    {
        private readonly ILogger<ApplicationController> _logger = logger;

        public void Run()
        {
            _logger.LogInformation("Started Corent Wallet.");
        }
    }
}
