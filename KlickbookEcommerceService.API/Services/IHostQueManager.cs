using KlickbookEcommerceService.API;
using DnsClient.Internal;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KlickbookEcommerceService.API;

public class IHostQueManager : IHostedService
{
    private readonly IBackgroundTaskQueue _taskQueue;

    private readonly ILogger<IHostQueManager> _logger;
    private readonly IMongoCollection<BsonDocument> _dbSMSLog;
    private readonly IMongoCollection<BsonDocument> _dbError;

    public IHostQueManager(ILogger<IHostQueManager> logger, IMongoClient mongoClient, IBackgroundTaskQueue taskQueue)
    => (_logger, _dbSMSLog, _dbError, _taskQueue) = (
        logger,
        mongoClient.GetDatabase("Notification").GetCollection<BsonDocument>("smslog"),
        mongoClient.GetDatabase("Notification").GetCollection<BsonDocument>("smserror"),
        taskQueue);



    public async Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
        $"{nameof(SMSQueManager)} is running.{Environment.NewLine}" +
        $"{Environment.NewLine}Tap W to add a work item to the " +
        $"background queue.{Environment.NewLine}");

        while (!cancellationToken.IsCancellationRequested)
        {
            ProcessTaskQueueAsync(cancellationToken);
            _logger.LogInformation("B.G. service is runing and process..., ", DateTime.Now);
            //Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken).Wait();
            await Task.Delay(TimeSpan.FromMilliseconds(100), cancellationToken);
        }

        //return Task.CompletedTask;
    }

    private async Task ProcessTaskQueueAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // 1
                for (int i = 0; i < 10; i++)
                {
                    _logger.LogInformation("here is service is running,..." + i);
                }



                // 2
                Func<CancellationToken, ValueTask>? workItem = await _taskQueue.DequeueAsync(stoppingToken);
                await workItem(stoppingToken);


                //3
                //BackgroundWorker tmpWorker = new BackgroundWorker();
                //tmpWorker.RunWorkerAsync(ExecuteService());

            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if stoppingToken was signaled
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing task work item.");
            }

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            $"{nameof(SMSQueManager)} is stopping.");

        return Task.CompletedTask;
        //throw new NotImplementedException();
    }
}
