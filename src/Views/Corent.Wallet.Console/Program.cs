using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Corent.Base.Extensions;
using Corent.Contracts.Services;
using Corent.Wallet.Console.Controllers;

namespace Corent.Wallet.Console
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the Corent Wallet
        /// console application.
        /// </summary>
        static void Main(string[] args)
        {
            System.Console.Title = "Corent Wallet Console Application";

            // setup our DI
            var serviceCollection = new ServiceCollection().AddLogging(cfg => cfg.AddConsole());

            // add Corent services using reflection
            serviceCollection.AddServicesFromAssembly(Assembly.GetAssembly(typeof(IMicroservice)));
            serviceCollection.AddServicesFromAssembly(Assembly.GetAssembly(typeof(ApplicationController)));

            // instantiate depenedency injection concrete object
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // start the application by getting the Application
            // class from the required services, and run it.
            serviceProvider.GetRequiredService<ApplicationController>().Run();

            return;
        }
    }
}