using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Corent.Base.Extensions;
using Corent.Contracts.Services;
using Corent.Logic.Services;

namespace Corent.Services.Wallet
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the Corrent Wallet microservice.
        /// </summary>
        private static void Main()
        {
            Console.Title = "Corent Wallet Microservice";

            // setup our DI
            var serviceCollection = new ServiceCollection().AddLogging(cfg => cfg.AddConsole());

            // add Corent services using reflection
            serviceCollection.AddServicesFromAssembly(Assembly.GetAssembly(typeof(WalletService)));

            // instantiate depenedency injection concrete object
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // start the application by getting the IWalletService from
            // the required services, and run it.
            serviceProvider.GetRequiredService<IWalletService>().Run();

            return;
        }
    }
}
