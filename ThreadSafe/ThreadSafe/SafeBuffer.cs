namespace ThreadSafe;

public class SafeBuffer<T> : IBuffer<T>
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly int _capacity;
    private readonly object _lock = new object();
    private readonly ILogger _logger;
    private bool _addingCompleted = false;

    public SafeBuffer(int capacity, ILogger logger)
    {
        _capacity = capacity > 0 ? capacity : throw new ArgumentException("Capacity must be greater than 0.", nameof(capacity));
        _logger = logger;
        _logger.LogInfo($"Buffer created with capacity: {_capacity}");
    }

    public bool IsAddingCompleted => _addingCompleted && _queue.Count == 0;

    public void Add(T item)
    {
        lock (_lock)
        {
            while (_queue.Count >= _capacity)
            {
                _logger.LogDebug("Buffer full, waiting to add...");
                Monitor.Wait(_lock);
            }
            _queue.Enqueue(item);
            _logger.LogInfo($"Item added to buffer: {item}");
            Monitor.PulseAll(_lock);
        }
    }

    public T Remove()
    {
        lock (_lock)
        {
            while (_queue.Count == 0)
            {
                if (_addingCompleted)
                {
                    _logger.LogDebug("No more items to process. Exiting...");
                    throw new InvalidOperationException("Buffer is empty, and adding is completed.");
                }
                _logger.LogDebug("Buffer empty, waiting to remove...");
                Monitor.Wait(_lock);
            }
            var item = _queue.Dequeue();
            _logger.LogInfo($"Item removed from buffer: {item}");
            Monitor.PulseAll(_lock);
            return item;
        }
    }

    public void CompleteAdding()
    {
        lock (_lock)
        {
            _addingCompleted = true;
            _logger.LogInfo("Producer has completed adding.");
            Monitor.PulseAll(_lock);
        }
    }
}