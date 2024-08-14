using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

using Corent.Base.Extensions;
using Corent.Contracts.Services;
using Corent.Network.Services;

namespace Corent.Services.Network
{

    public class Program
    {
        /// <summary>
        /// The main entry point for the Corrent Wallet microservice.
        /// </summary>
        static void Main(string[] args)
        {
            Console.Title = "Corent Network Microservice";

            // setup our DI
            new ServiceCollection().AddLogging(cfg => cfg.AddConsole())
                .AddSingleton<IConnectionFactory, ConnectionFactory>()
                .AddServicesFromAssembly(Assembly.GetAssembly(typeof(NetworkService)))
                .BuildServiceProvider()
                .GetRequiredService<INetworkService>().Run();

            return;
        }
    }
}
