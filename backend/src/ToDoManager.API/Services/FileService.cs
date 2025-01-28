using ToDoManager.API.Interfaces;
using ToDoManager.Domain.Entities;
using ToDoManager.Infrastructure;

namespace ToDoManager.API.Services;

public class FileService : IFileService
{
    private readonly string _storagePath;

    public FileService(IConfiguration configuration)
    {
        var rootPath = Directory.GetCurrentDirectory();
        _storagePath = Path.Combine(rootPath, configuration["FileStorage:Path"] ?? "FileStorage");

        if (!Directory.Exists(_storagePath))
        {
            Directory.CreateDirectory(_storagePath);
        }
    }

    public async Task<string> UploadFileAsync(IFormFile file, string entityName, int entityId)
    {
        var fileDirectory = Path.Combine(_storagePath, entityName, entityId.ToString());
        if (!Directory.Exists(fileDirectory))
        {
            Directory.CreateDirectory(fileDirectory);
        }

        var filePath = Path.Combine(fileDirectory, file.FileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return filePath;
    }

    public Stream? DownloadFile(string filePath)
    {
        if (filePath == null)
        {
            return null;
        }

        return new FileStream(filePath, FileMode.Open, FileAccess.Read);
    }

    public bool DeleteFile(string filePath)
    {
        if (filePath == null || !File.Exists(filePath))
        {
            return false;
        }

        File.Delete(filePath);

        return true;
    }

    public bool DeleteDirectory(string entityName, int entityId)
    {
        var directoryPath = Path.Combine(_storagePath, entityName, entityId.ToString());
        if (directoryPath == null || !Directory.Exists(directoryPath))
        {
            return false;
        }

        Directory.Delete(directoryPath, recursive: true);

        return true;
    }
}
