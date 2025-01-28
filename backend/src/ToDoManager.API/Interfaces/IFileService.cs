namespace ToDoManager.API.Interfaces;

public interface IFileService
{
    Task<string> UploadFileAsync(IFormFile file, string entityName, int entityId);

    Stream? DownloadFile(string filePath);

    bool DeleteFile(string filePath);

    bool DeleteDirectory(string entityName, int entityId);
}
