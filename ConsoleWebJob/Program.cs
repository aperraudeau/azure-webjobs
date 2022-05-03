using ConsoleWebJob.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleWebJob
{
    internal static class Program
    {
        private static async Task Main()
        {
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
               .Build();

            var startup = new Startup(configuration);

            var builder = new HostBuilder();
            builder.ConfigureLogging(logging =>
            {
                logging.AddConsole();
            });

            builder.ConfigureWebJobs(b =>
            {
                b.AddAzureStorageCoreServices();
                b.AddAzureStorageBlobs();
                b.AddTimers();
            });

            builder.ConfigureServices(serviceCollection =>
            {
                startup.Configure(serviceCollection);
            });

            using var host = builder.Build();

#if DEBUG
            // Avoid the lock on blob made by azure webjobs once it is deployed
            IDemoJob demoJob = host.Services.GetService<IDemoJob>();
            await demoJob.Process();
#else
            await host.RunAsync();
#endif
        }
    }
}