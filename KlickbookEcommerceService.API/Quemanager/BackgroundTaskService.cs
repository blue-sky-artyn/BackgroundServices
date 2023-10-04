namespace KlickbookEcommerceService.API.Quemanager;

public class BackgroundTaskService : BackgroundService
{
    private readonly IBackgroundTaskQueue _taskQueue;

    public BackgroundTaskService(IBackgroundTaskQueue _taskQueue)
    => this._taskQueue = _taskQueue;

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var workItem = await _taskQueue.DequeueAsync(stoppingToken);

            try
            {
                if (workItem != null)
                {
                    await workItem(stoppingToken);
                }
            }
            catch (Exception)
            {
                // Log the exception if necessary
            }
        }
    }
}
