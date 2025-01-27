//using Microsoft.AspNetCore.Mvc;
//using ToDoManager.Application.Services;

//namespace ToDoManager.API.Controllers;

//[ApiController]
//[Route("api/files")]
//public class FilesController : ControllerBase
//{
//    private readonly IFileService _fileService;

//    public FilesController(IFileService fileService)
//    {
//        _fileService = fileService;
//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateFile(IFormFile file)
//    {
//        var test = file;
//        return Ok();
//    }

//    /// <summary>
//    /// Загрузка файла
//    /// </summary>
//    [HttpPost("upload")]
//    public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
//    {
//        if (file == null || file.Length == 0)
//            return BadRequest("Файл не загружен");

//        using var stream = file.OpenReadStream();
//        await _fileService.UploadFileAsync(file.FileName, stream);

//        return Ok(new { FileName = file.FileName, Size = file.Length });
//    }

//    /// <summary>
//    /// Скачивание файла
//    /// </summary>
//    [HttpGet("download/{fileName}")]
//    public async Task<IActionResult> DownloadFile(string fileName)
//    {
//        var fileStream = await _fileService.DownloadFileAsync(fileName);
//        return File(fileStream, "application/octet-stream", fileName);
//    }

//    /// <summary>
//    /// Удаление файла
//    /// </summary>
//    [HttpDelete("delete/{fileName}")]
//    public async Task<IActionResult> DeleteFile(string fileName)
//    {
//        await _fileService.DeleteFileAsync(fileName);
//        return Ok(new { Status = "Файл удален", FileName = fileName });
//    }
//}
