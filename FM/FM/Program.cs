namespace FM;

public static class Program
{
    public static async Task Main()
    {
        Console.WriteLine("Welcome to FileManager!");
        await Controller.RunAsync();
    }
}
