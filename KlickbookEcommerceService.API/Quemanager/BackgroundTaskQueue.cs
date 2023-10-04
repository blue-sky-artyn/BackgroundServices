using System.Threading.Tasks;
using System.Threading;
using System;
using System.Threading.Channels;
using System.Collections.Concurrent;

namespace KlickbookEcommerceService.API;

//https://stackoverflow.com/questions/52163500/net-core-web-api-with-queue-processing

public interface IBackgroundTaskQueue
{
    void QueueBackgroundWorkItem(Func<CancellationToken, ValueTask> workItem);
    Task<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);





    //ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem);
    //ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync1(CancellationToken cancellationToken);
}

public sealed class BackgroundTaskQueue : IBackgroundTaskQueue
{
    //private readonly Channel<Func<CancellationToken, ValueTask>> _queue;
    private readonly ConcurrentQueue<Func<CancellationToken, ValueTask>> _workItems = new();
    
    private readonly SemaphoreSlim _signal = new(0);

    //public BackgroundTaskQueue(int capacity)
    //{
    //    BoundedChannelOptions options = new BoundedChannelOptions(capacity)
    //    {
    //        FullMode = BoundedChannelFullMode.Wait
    //    };
    //    _queue = Channel.CreateBounded<Func<CancellationToken, ValueTask>>(options);
    //}

    //public async ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem)
    //{
    //    _ = workItem ?? throw new ArgumentNullException(nameof(workItem));
        
    //    await _queue.Writer.WriteAsync(workItem);
    //}

    //public async ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync1(CancellationToken cancellationToken)
    //{
    //    //1
    //    Func<CancellationToken, ValueTask>? workItem1 = await _queue.Reader.ReadAsync(cancellationToken);
        
    //    //2
    //    await _signal.WaitAsync(cancellationToken);
    //    _workItems.TryDequeue(out var workItem2);
    //    //return workItem2;




    //    return workItem1;
    //}



    public void QueueBackgroundWorkItem(Func<CancellationToken, ValueTask> workItem)
    {
        _ = workItem ?? throw new ArgumentNullException(nameof(workItem));

        _workItems.Enqueue(workItem);
        _signal.Release();
    }

    public async Task<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken)
    {
        await _signal.WaitAsync(cancellationToken);
        _workItems.TryDequeue(out var workItem);

        return workItem!;
    }
}
