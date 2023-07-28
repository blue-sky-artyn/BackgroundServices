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

public class SMSQueManager : BackgroundService
{
    private readonly IBackgroundTaskQueue _taskQueue;

    private readonly ILogger<SMSQueManager> _logger;
    private readonly IMongoCollection<BsonDocument> _dbSMSLog;
    private readonly IMongoCollection<BsonDocument> _dbError;

    public SMSQueManager(ILogger<SMSQueManager> logger, IMongoClient mongoClient, IBackgroundTaskQueue taskQueue)
    => (_logger, _dbSMSLog, _dbError, _taskQueue) = (
        logger,
        mongoClient.GetDatabase("Notification").GetCollection<BsonDocument>("smslog"),
        mongoClient.GetDatabase("Notification").GetCollection<BsonDocument>("smserror"),
        taskQueue);

    //protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
        $"{nameof(SMSQueManager)} is running.{Environment.NewLine}" +
        $"{Environment.NewLine}Tap W to add a work item to the " +
        $"background queue.{Environment.NewLine}");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                ProcessTaskQueueAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("There was an error while the processes messgaes in QUE, " + ex.Message);
            }
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        //return Task.CompletedTask;
    }


    private async Task ProcessTaskQueueAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                Func<CancellationToken, ValueTask>? workItem = await _taskQueue.DequeueAsync(stoppingToken);

                BackgroundWorker tmpWorker = new BackgroundWorker();
                tmpWorker.RunWorkerAsync(ExecuteService());

                await workItem(stoppingToken);
            }
            catch (OperationCanceledException)
            {
                // Prevent throwing if stoppingToken was signaled
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred executing task work item.");
            }
        }
    }

    public Task ExecuteService()
    {
        try
        {
            ThisIsToRun();

            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }




    public async Task ThisIsToRun()
    {
        try
        {
            for (int i = 0; i < 10; i++)
            {
                _logger.LogInformation("here is service is running,..." + i);
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public override async Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            $"{nameof(SMSQueManager)} is stopping.");

        await base.StopAsync(stoppingToken);
    }



}
