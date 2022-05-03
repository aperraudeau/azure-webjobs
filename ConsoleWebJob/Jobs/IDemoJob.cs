using System.Threading.Tasks;

namespace ConsoleWebJob.Jobs
{
    public interface IDemoJob
    {
        Task Process();
    }
}