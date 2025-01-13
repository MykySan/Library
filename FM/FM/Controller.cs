namespace FM;

public static class Controller
{
    public static async Task RunAsync()
    {
        IFileManager fileManager = new FileManager("MyRootDirectory");

        while (true)
        {
            Console.WriteLine("Type a command (help for list of commands):");
            var command = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (string.IsNullOrWhiteSpace(command))
                continue;

            switch (command)
            {
                case "help":
                    PrintHelp();
                    break;

                case "create":
                    Console.Write("Enter name of file to create: ");
                    var createFileName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(createFileName))
                    {
                        await DiagnosticsTimer.MeasureAsync(
                            "CreateFile",
                            () => fileManager.CreateFileAsync(createFileName)
                        );
                    }
                    else
                    {
                        Console.WriteLine("Incorrect file name.");
                    }
                    break;

                case "write":
                    Console.Write("Enter file name for writing: ");
                    var writeFileName = Console.ReadLine();
                    Console.Write("Enter data for writing: ");
                    var content = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(writeFileName) && content != null)
                    {
                        await DiagnosticsTimer.MeasureAsync(
                            "WriteToFile",
                            () => fileManager.WriteToFileAsync(writeFileName, content)
                        );
                    }
                    else
                    {
                        Console.WriteLine("Incorrect data for writing.");
                    }
                    break;

                case "read":
                    Console.Write("Enter file name to read: ");
                    var readFileName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(readFileName))
                    {
                        await DiagnosticsTimer.MeasureAsync(
                            "ReadFile",
                            () => fileManager.ReadFileAsync(readFileName)
                        );
                    }
                    else
                    {
                        Console.WriteLine("Incorrect file name.");
                    }
                    break;

                case "delete":
                    Console.Write("Enter file name to delete: ");
                    var deleteFileName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(deleteFileName))
                    {
                        await DiagnosticsTimer.MeasureAsync(
                            "DeleteFile",
                            () => fileManager.DeleteFileAsync(deleteFileName)
                        );
                    }
                    else
                    {
                        Console.WriteLine("Incorrect file name.");
                    }
                    break;

                case "list":
                    await DiagnosticsTimer.MeasureAsync(
                        "ListFiles",
                        fileManager.ListFilesAsync
                    );
                    break;

                case "exit":
                    Console.WriteLine("Closing FileManager. See you!");
                    return;

                default:
                    Console.WriteLine("Unknown command. type 'help' for a list of commands.");
                    break;
            }
        }
    }

    public static void PrintHelp()
    {
        Console.WriteLine(
@"Доступные команды:
  help     - commands list
  create   - create file
  write    - write in file (append)
  read     - read file
  delete   - delete file
  list     - show list of files
  exit     - close FileManager
");
    }
}

