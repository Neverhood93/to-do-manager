namespace ToDoManager.Application.Services;

public interface IFileService
{
    Task UploadFileAsync(string fileName, Stream fileStream);

    Task<Stream> DownloadFileAsync(string fileName);

    Task DeleteFileAsync(string fileName);
}