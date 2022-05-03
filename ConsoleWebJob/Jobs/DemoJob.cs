using ConsoleWebJob.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ConsoleWebJob.Jobs
{
    public class DemoJob : IDemoJob
    {
        private readonly ILogger<DemoJob> _logger;
        private readonly IOptions<DemoOptions> _options;

        public DemoJob(
            IOptions<DemoOptions> options,
            ILogger<DemoJob> logger)
        {
            _options = options;
            _logger = logger;
        }

        public async Task Process()
        {
            _logger.LogInformation(string.Format("Hello {0}", _options.Value.MyParameter));
            await Task.CompletedTask;
        }
    }
}