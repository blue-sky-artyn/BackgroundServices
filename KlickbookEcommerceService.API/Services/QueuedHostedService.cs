using KlickbookEcommerceService.Common;

namespace KlickbookEcommerceService.API.Services;

public class QueuedHostedService : BackgroundService
{
    private readonly ILogger _logger;
    private Timer? _timer = null;
    private readonly IScopedProcessingService _process;

    public QueuedHostedService(IBackgroundTaskQueue taskQueue,ILoggerFactory loggerFactory, IScopedProcessingService _process)
    {
        TaskQueue = taskQueue;
        _logger = loggerFactory.CreateLogger<QueuedHostedService>();
        this._process = _process;
    }

    public IBackgroundTaskQueue TaskQueue { get; }
    public IServiceProvider Services { get; }

    protected async override Task ExecuteAsync(CancellationToken cancellationToken)
    {
        

        _logger.LogInformation("Queued Hosted Service is starting.");

        //_timer = new Timer(_process.DoWork(cancellationToken), null, TimeSpan.Zero, TimeSpan.FromSeconds(5));

        while (!cancellationToken.IsCancellationRequested)
        {
            var workItem = await TaskQueue.DequeueAsync(cancellationToken);

            try
            {
                await workItem(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,
                   $"Error occurred executing {nameof(workItem)}.");
            }
        }

        _logger.LogInformation("Queued Hosted Service is stopping.");
    }

}













public interface IScopedProcessingService
{
    Task DoWork(CancellationToken stoppingToken);
}

public class ScopedProcessingService : IScopedProcessingService
{
    private int executionCount = 0;
    private readonly ILogger _logger;

    public ScopedProcessingService(ILogger<ScopedProcessingService> logger)
    {
        _logger = logger;
    }

    public async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            executionCount++;

            _logger.LogInformation(
                "Scoped Processing Service is working. Count: {Count}", executionCount);

            await Task.Delay(10000, stoppingToken);
        }
    }
}