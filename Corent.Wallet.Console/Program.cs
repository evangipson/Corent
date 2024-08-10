using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Corent.Base.Extensions;
using Corent.Wallet.Console.Controllers.Interfaces;

namespace Corent.Wallet.Console
{
    internal class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// A list of arguments provided to the application.
        /// </param>
        private static void Main()
        {
            System.Console.Title = "Corent Wallet";

            // setup our DI
            var serviceCollection = new ServiceCollection().AddLogging(cfg => cfg.AddConsole());

            // add Corent services using reflection
            serviceCollection.AddServicesFromAssembly(Assembly.GetAssembly(typeof(IApplicationController)));

            // instantiate depenedency injection concrete object
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // start the application by getting the Application
            // class from the required services, and run it.
            serviceProvider.GetRequiredService<IApplicationController>().Run();

            return;
        }
    }
}