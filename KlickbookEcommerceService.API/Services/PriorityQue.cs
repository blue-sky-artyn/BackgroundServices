﻿using System.Collections.Generic;
using System.Diagnostics;
using KlickbookEcommerceService.Common;

namespace KlickbookEcommerceService.API.Services;

//Priority Queue
//https://www.youtube.com/watch?v=4XSSC6uPFNA

public class PriorityQue : BackgroundService
{
    private readonly ILogger<PriorityQue> _logger;

    public PriorityQue(ILogger<PriorityQue> _logger)
        => this._logger = _logger;

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
