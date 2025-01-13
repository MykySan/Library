namespace FM;

public interface IFileManager
{
    Task CreateFileAsync(string fileName);
    Task WriteToFileAsync(string fileName, string content);
    Task ReadFileAsync(string fileName);
    Task DeleteFileAsync(string fileName);
    Task ListFilesAsync();
}

