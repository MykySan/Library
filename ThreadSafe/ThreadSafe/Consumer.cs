namespace ThreadSafe;

public class Consumer(IBuffer<int> buffer, ILogger logger)
{
    private readonly IBuffer<int> _buffer = buffer;

    public void Run()
    {
        while (true)
        {
            try
            {
                var number = _buffer.Remove();
                var square = number * number;
                Console.WriteLine($"Number: {number}, Square: {square}");
                logger.LogInfo($"Processed number: {number}, Square: {square}");
                Thread.Sleep(500);
            }
            catch (InvalidOperationException)
            {
                logger.LogInfo("Consumer completed.");
                break;
            }
            catch (Exception ex)
            {
                logger.LogError($"Consumer error: {ex.Message}");
            }
        }
    }
}