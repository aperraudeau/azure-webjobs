using Microsoft.Azure.WebJobs;
using System.Threading.Tasks;

namespace ConsoleWebJob.Jobs
{
    public class TriggerJob
    {
        private readonly IDemoJob _demoJob;

        public TriggerJob(IDemoJob demoJob)
        {
            _demoJob = demoJob;
        }

        // Everyday at 05:00:00
        public async Task ProcessOnTimer([TimerTrigger("0 00 5 * * *", RunOnStartup = true)] TimerInfo timerInfo)
        {
            await _demoJob.Process();
        }
    }
}