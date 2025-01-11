namespace ThreadSafe;

public interface ILogger
{
    void LogInfo(string message);
    void LogError(string message);
    void LogDebug(string message);
}