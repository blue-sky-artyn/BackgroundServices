using System.Collections.Generic;
using System.Diagnostics;
using KlickbookEcommerceService.Common;
using KlickbookEcommerceService.Service;

namespace KlickbookEcommerceService.API.Services;

//Priority Queue
//https://www.youtube.com/watch?v=4XSSC6uPFNA

public class PriorityQueComplex : BackgroundService
{
    private readonly ILogger<PriorityQueComplex> _logger;
    //private IBackgroundTaskQueue _queue;
    private readonly ISampleService _sampleservice;
    private readonly IBackgroundTaskQueue _backgroundTaskQueue;

    public PriorityQueComplex(ILogger<PriorityQueComplex> _logger, IBackgroundTaskQueue _queue, ISampleService _sampleservice, IBackgroundTaskQueue _backgroundTaskQueue)
        => (this._logger, this._sampleservice, this._backgroundTaskQueue) = (_logger, _sampleservice, _backgroundTaskQueue);

    #region Declaration
    class StatusComparer : IComparer<(Status, long)>
    {

        public static StatusComparer Instance { get; } = new();
        private StatusComparer() { }

        public int Compare((Status, long) x, (Status, long) y)
        {
            if (x.Item1 == y.Item1)
            {
                return x.CompareTo(y);
            }

            return y.CompareTo(x);
        }
    }

    record User(string value);
    #endregion


    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        #region create the line of jobs
        //var priorityQueue = new PriorityQueue<string, int>();
        //var priorityQueue = new PriorityQueue<string, (Status,long)>(StatusComparer.Instance);
        var priorityQueue = new PriorityQueue<string, (Status, long)>(StatusComparer.Instance);

        priorityQueue.Enqueue("Item 1", (Status.Bronz, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 2", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 3", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 4", (Status.Gold, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 5", (Status.Bronz, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 6", (Status.Gold, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 7", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 8", (Status.Gold, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 9", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item 10", (Status.Bronz, Stopwatch.GetTimestamp()));
        #endregion

        _logger.LogInformation($@"{nameof(PriorityQue)} is running.{Environment.NewLine}
            {priorityQueue.Count} job(s) is/are in the line to be proceeded.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
                {
                    await _sampleservice.RunThePriorityQueue(priorityQueue, token);
                });





                //await _queue.QueueBackgroundWorkItemAsync(async (token) =>
                //{
                //    //await _mailService.SendAsync(mailData, token);

                //    while (priorityQueue.TryDequeue(out string queueItem, out (Status, long) priority))
                //    {
                //        Console.WriteLine($"Item : {queueItem}. Priority : {priority}");
                //        _logger.LogInformation($"Item : {queueItem}. Priority : {priority}");
                //    }
                //});
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"error : {ex.Message}");
            }
        }


        //PeriodicTimer timer = new(TimeSpan.FromMilliseconds(1000));
        //while (await timer.WaitForNextTickAsync(stoppingToken))
        //{
        //    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        //}


    }


    public void ExcutePriorityque()
    {
        throw new NotImplementedException();
    }

}
