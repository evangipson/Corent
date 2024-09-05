using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

using Corent.Base.Extensions;
using Corent.Contracts.Services;
using Corent.Domain.Options;
using Corent.Logic.Services;
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
            IServiceCollection services = new ServiceCollection();
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", false, true)
                .AddEnvironmentVariables()
                .Build();

            services.AddOptions<CorentNetwork>().Bind(configuration.GetSection(nameof(CorentNetwork)));

            services.AddLogging(cfg => cfg.AddConsole())
                .AddSingleton<IConnectionFactory, ConnectionFactory>()
                .AddServicesFromAssembly(Assembly.GetAssembly(typeof(MessageService)))
                .AddServicesFromAssembly(Assembly.GetAssembly(typeof(NetworkService)))
                .BuildServiceProvider()
                .GetRequiredService<INetworkService>().Run();

            return;
        }
    }
}
