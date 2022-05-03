using ConsoleWebJob.Jobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleWebJob
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void Configure(IServiceCollection services)
        {
            services.AddScoped<IDemoJob, DemoJob>();
        }
    }
}
