using Demo.TestingKits.Services.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Services
{
    public class ProcessingManager : IProcessingManager
    {
        private readonly List<IJob> _jobs = new List<IJob>();

        public bool HasPendingJobs => _jobs.Any(x => !x.IsCompleted);
        public int CountPendingJobs => _jobs.Count(x => !x.IsCompleted);

        public void AddJobs(IJob job)
        {
            _jobs.Add(job);
        }

        public void ProcessPendingJobs()
        {
            foreach (var job in _jobs.Where(x => !x.IsCompleted))
            {
                job.Execute();
            }
        }

    }
}
