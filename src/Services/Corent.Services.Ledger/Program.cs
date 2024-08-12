using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

using Corent.Base.Extensions;
using Corent.Contracts.Services;
using Corent.Logic.Services;

namespace Corent.Services.Ledger
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the Corrent Ledger microservice.
        /// </summary>
        static void Main(string[] args)
        {
            Console.Title = "Corent Ledger Microservice";

            // setup our DI
            new ServiceCollection().AddLogging(cfg => cfg.AddConsole())
                .AddSingleton<IConnectionFactory, ConnectionFactory>()
                .AddServicesFromAssembly(Assembly.GetAssembly(typeof(LedgerService)))
                .BuildServiceProvider()
                .GetRequiredService<ILedgerService>().Run();

            return;
        }
    }
}
