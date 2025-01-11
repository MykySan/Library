namespace ThreadSafe;

public class Producer(IBuffer<int> buffer, ILogger logger)
{
    private readonly IBuffer<int> _buffer = buffer;
    private readonly Random _random = new Random();
    public void Run()
    {
        for (var i = 0; i <= 10; i++)
        {
            try
            {
                var randomNumber = _random.Next(1, 100);
                _buffer.Add(randomNumber);
                Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                logger.LogError($"Producer error: {ex.Message}");
            }
        }
        _buffer.CompleteAdding();
        logger.LogInfo("Producer completed.");
    }
}

