using System.Text;

namespace FM;

public class FileManager : IFileManager
{
    private readonly string _rootDirectory;

    public FileManager(string rootDirectory)
    {
        _rootDirectory = rootDirectory;
        if (!Directory.Exists(_rootDirectory))
        {
            Directory.CreateDirectory(_rootDirectory);
        }
    }

    public async Task CreateFileAsync(string fileName)
    {
        var fullPath = Path.Combine(_rootDirectory, fileName);
        if (File.Exists(fullPath))
        {
            Console.WriteLine($"File '{fileName}' already exists.");
            return;
        }

        using var fs = new FileStream(fullPath, FileMode.CreateNew, FileAccess.Write, FileShare.None, 4096, useAsync: true);
        {
            var info = Encoding.UTF8.GetBytes("File created at " + DateTime.Now);
            await fs.WriteAsync(info, 0, info.Length);
        }

        Console.WriteLine($"File '{fileName}' succesfully created in '{_rootDirectory}'.");
    }

    public async Task WriteToFileAsync(string fileName, string content)
    {
        var fullPath = Path.Combine(_rootDirectory, fileName);
        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File '{fileName}' not found.");
            return;
        }

        using var fs = new FileStream(fullPath, FileMode.Append, FileAccess.Write, FileShare.None, 4096, useAsync: true);
        {
            var info = Encoding.UTF8.GetBytes(content + Environment.NewLine);
            await fs.WriteAsync(info, 0, info.Length);
        }

        Console.WriteLine($"Data successfully written to file '{fileName}'.");
    }

    public async Task ReadFileAsync(string fileName)
    {
        var fullPath = Path.Combine(_rootDirectory, fileName);
        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File '{fileName}' not found.");
            return;
        }

        using var fs = new FileStream(fullPath, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, useAsync: true);
        using var reader = new StreamReader(fs);
        {
            var content = await reader.ReadToEndAsync();
            Console.WriteLine($"File content '{fileName}':");
            Console.WriteLine(content);
        }
    }

    public Task DeleteFileAsync(string fileName)
    {
        var fullPath = Path.Combine(_rootDirectory, fileName);
        if (!File.Exists(fullPath))
        {
            Console.WriteLine($"File '{fileName}' not found.");
            return Task.CompletedTask;
        }

        File.Delete(fullPath);
        Console.WriteLine($"File '{fileName}' deleted.");
        return Task.CompletedTask;
    }

    public Task ListFilesAsync()
    {
        var files = Directory.GetFiles(_rootDirectory);
        if (files.Length == 0)
        {
            Console.WriteLine("There are no files in the directory.");
        }
        else
        {
            Console.WriteLine("List of files:");
            foreach (var file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
        return Task.CompletedTask;
    }
}

