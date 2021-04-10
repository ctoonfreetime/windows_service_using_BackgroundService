using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace myService
{
    internal interface IWorkerScope
    {
        Task DoWork(CancellationToken stoppingToken);
    }
}
