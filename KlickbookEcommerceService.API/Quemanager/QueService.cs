using System.Threading.Tasks;
using System.Threading;
using System;
using System.Threading.Channels;
using System.Collections.Concurrent;

namespace KlickbookEcommerceService.API;

//https://stackoverflow.com/questions/52163500/net-core-web-api-with-queue-processing

public interface IBackgroundTaskQueue
{
    ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem);
    void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem);

    ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken);
    //Task<Func<CancellationToken, Task>> DequeueAsync(CancellationToken cancellationToken);
}

public sealed class QueService : IBackgroundTaskQueue
{
    private readonly Channel<Func<CancellationToken, ValueTask>> _queue;
    private ConcurrentQueue<Func<CancellationToken, Task>> _workItems = new ConcurrentQueue<Func<CancellationToken, Task>>();
    private SemaphoreSlim _signal = new SemaphoreSlim(0);


    public QueService(int capacity)
    {
        BoundedChannelOptions options = new BoundedChannelOptions(capacity)
        {
            FullMode = BoundedChannelFullMode.Wait
        };
        _queue = Channel.CreateBounded<Func<CancellationToken, ValueTask>>(options);
    }

    public async ValueTask QueueBackgroundWorkItemAsync(Func<CancellationToken, ValueTask> workItem)
    {
        _ = workItem ?? throw new ArgumentNullException(nameof(workItem));
        
        await _queue.Writer.WriteAsync(workItem);
    }

    public void QueueBackgroundWorkItem(Func<CancellationToken, Task> workItem)
    {
         _ = workItem ?? throw new ArgumentNullException(nameof(workItem));

        _workItems.Enqueue(workItem);
        _signal.Release();
    }



    public async ValueTask<Func<CancellationToken, ValueTask>> DequeueAsync(CancellationToken cancellationToken)
    {
        //1
        Func<CancellationToken, ValueTask>? workItem1 = await _queue.Reader.ReadAsync(cancellationToken);
        
        //2
        await _signal.WaitAsync(cancellationToken);
        _workItems.TryDequeue(out var workItem2);
        //return workItem2;




        return workItem1;
    }
}
