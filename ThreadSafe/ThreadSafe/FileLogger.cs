namespace ThreadSafe;

public class FileLogger : ILogger
{
    private readonly string _logFile;

    public FileLogger(string filePath = "app_log.txt")
    {
        _logFile = filePath;
        if (!File.Exists(_logFile))
        {
            File.WriteAllText(_logFile, string.Empty);
        }
    }

    public void LogInfo(string message)
    {
        Log("INFO", message);
    }

    public void LogError(string message)
    {
        Log("ERROR", message);
    }

    public void LogDebug(string message)
    {
        Log("DEBUG", message);
    }

    private void Log(string level, string message)
    {
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
        Console.WriteLine(logMessage);
        File.AppendAllText(_logFile, logMessage + Environment.NewLine);
    }
}


