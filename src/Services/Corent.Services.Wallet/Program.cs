using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

using Corent.Base.Extensions;
using Corent.Contracts.Services;
using Corent.Logic.Services;

namespace Corent.Services.Wallet
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the Corrent Wallet microservice.
        /// </summary>
        static void Main(string[] args)
        {
            Console.Title = "Corent Wallet Microservice";

            // setup our DI
            new ServiceCollection().AddLogging(cfg => cfg.AddConsole())
                .AddSingleton<IConnectionFactory, ConnectionFactory>()
                .AddServicesFromAssembly(Assembly.GetAssembly(typeof(WalletService)))
                .BuildServiceProvider()
                .GetRequiredService<IWalletService>().Run();

            return;
        }
    }
}
