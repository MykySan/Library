namespace ThreadSafe;

public static class Program
{
    public static void Main()
    {
        ILogger logger = new FileLogger("buffer_log.txt");
        IBuffer<int> buffer = new SafeBuffer<int>(5, logger);

        var producer = new Producer(buffer, logger);
        var consumer = new Consumer(buffer, logger);

        var producerThread = new Thread(producer.Run);
        var consumerThread = new Thread(consumer.Run);

        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();

        Console.WriteLine("All tasks completed.");
        logger.LogInfo("Program finished.");
    }
}
