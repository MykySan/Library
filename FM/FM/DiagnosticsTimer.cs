using System.Diagnostics;

namespace FM;

public static class DiagnosticsTimer
{
    public static async Task MeasureAsync(string operationName, Func<Task> action)
    {
        var sw = new Stopwatch();
        sw.Start();

        try
        {
            await action.Invoke();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during operation '{operationName}': {ex.Message}");
        }
        finally
        {
            sw.Stop();
            Console.WriteLine($"Operation '{operationName}' completed in {sw.ElapsedMilliseconds} ms.\n");
        }
    }
}

