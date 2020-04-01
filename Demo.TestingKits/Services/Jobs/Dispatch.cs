using Demo.TestingKits.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.TestingKits.Services.Jobs
{
    public class Dispatch : IJob
    {
        private readonly Order _order;
        public Dispatch(Order order)
        {
            _order = order;
            IsCompleted = false;
        }

        public bool IsCompleted { get; set; }

        public void Execute()
        {
            //TODO Do something here to dispatch orders waiting to go

            IsCompleted = true;
        }
        

    }
}
