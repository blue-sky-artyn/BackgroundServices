using System.Collections.Generic;
using System.Diagnostics;

namespace KlickbookEcommerceService.API.Services;

//Priority Queue
//https://www.youtube.com/watch?v=4XSSC6uPFNA

public class PriorityQue : BackgroundService
{
    private readonly ILogger<PriorityQue> _logger;

    public PriorityQue(ILogger<PriorityQue> _logger)
        => this._logger = _logger;
    enum Status
    {
        Gold,
        Platinum,
        Bronz
    }

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

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        //var priorityQueue = new PriorityQueue<string, int>();
        //var priorityQueue = new PriorityQueue<string, (Status,long)>(StatusComparer.Instance);
        var priorityQueue = new PriorityQueue<string, (Status, long)>(StatusComparer.Instance);

        priorityQueue.Enqueue("Item A", (Status.Bronz, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item B", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item C", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item D", (Status.Gold, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item E", (Status.Bronz, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item F", (Status.Gold, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item G", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item H", (Status.Gold, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item I", (Status.Platinum, Stopwatch.GetTimestamp()));
        priorityQueue.Enqueue("Item J", (Status.Bronz, Stopwatch.GetTimestamp()));

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                while (priorityQueue.TryDequeue(out string queueItem, out (Status, long) priority))
                {
                    Console.WriteLine($"Item : {queueItem}. Priority : {priority}");
                    _logger.LogInformation($"Item : {queueItem}. Priority : {priority}");
                }
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
