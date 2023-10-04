using Amazon.Runtime.Internal.Util;
using KlickbookEcommerceService.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.Service
{
    public interface ISampleService
    {
        Task RunThePriorityQueue(PriorityQueue<string, (Status, long)> priorityQueue, CancellationToken token);
    }

    public class SampleService : ISampleService
    {
        private readonly ILogger<SampleService> _logger;

        public SampleService(ILogger<SampleService> _logger)
            => this._logger = _logger;


        //public bool RunThePriorityQueue(PriorityQueue<string, (Status, long)> priorityQueue)
        public async Task RunThePriorityQueue(PriorityQueue<string, (Status, long)> priorityQueue, CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    await Task.Run(() =>
                    {
                        while (priorityQueue.TryDequeue(out string queueItem, out (Status, long) priority))
                        {
                            Console.WriteLine($"Item : {queueItem}. Priority : {priority}");
                            _logger.LogInformation($"Item : {queueItem}. Priority : {priority}");
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
