using Demo.TestingKits.Services.Jobs;

namespace Demo.TestingKits.Services
{
    public interface IProcessingManager
    {
        int CountPendingJobs { get; }
        bool HasPendingJobs { get; }

        void AddJobs(IJob job);
        void ProcessPendingJobs();
    }
}