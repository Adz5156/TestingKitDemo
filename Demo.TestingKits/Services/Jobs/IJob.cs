using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Services.Jobs
{
    public interface IJob
    {
        bool IsCompleted { get; set; }
        void Execute();
    }
}
