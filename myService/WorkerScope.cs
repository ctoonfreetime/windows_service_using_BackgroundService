using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace myService
{
    internal class WorkerScope: IWorkerScope
    {
        private ApiService _apiService;
        public WorkerScope(ApiService apiService) {
            _apiService = apiService;
        }

        public async Task DoWork(CancellationToken stoppingToken) {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // write current datetime to result.txt every 1 second.
                    using (StreamWriter writer = File.CreateText("result.txt"))
                    {
                        writer.WriteLine(_apiService.GetData().ToString());
                    }
                }
                catch { 
                
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
