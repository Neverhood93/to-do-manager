using Microsoft.AspNetCore.Mvc;
using ToDoManager.API.Interfaces;
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Application.Interfaces.Services;
using ToDoManager.Domain.Entities;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/files")]
public class ToDoFilesController : ControllerBase
{
    private readonly IFileService _fileService;
    private readonly IToDoFileRepository _toDoFileRepository;
    private readonly IToDoFileService _toDoFileService;

    public ToDoFilesController(IFileService fileService, 
        IToDoFileRepository toDoFileRepository, 
        IToDoFileService toDoFileService)
    {
        _fileService = fileService;
        _toDoFileRepository = toDoFileRepository;
        _toDoFileService = toDoFileService;
    }

    [HttpPost("upload/todoid/{todoid:int}")]
    public async Task<IActionResult> UploadFile(IFormFile file, int todoid)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Файл не загружен");
        }

        var filePath = await _fileService.UploadFileAsync(file, "todo", todoid);

        var toDoFile = await _toDoFileService.CreateAsync(
            new ToDoFile
            {
                Name = file.FileName,
                Path = filePath,
                ContentType = file.ContentType,
                Length = file.Length,
            }, 
            todoid);

        if (toDoFile == null)
        {
            return BadRequest("Задача не найдена");
        }

        return Ok(toDoFile);
    }

    [HttpGet("download/{fileId}")]
    public async Task<IActionResult> DownloadFile(Guid fileId)
    {
        var toDoFile = await _toDoFileService.GetByIdAsync(fileId);
        if (toDoFile == null) 
        {
            return BadRequest("Файл не найден");
        }        

        var fileStream = _fileService.DownloadFile(toDoFile.Path);
        if (fileStream == null)
        {
            return NotFound();
        }

        return File(fileStream, toDoFile.ContentType, toDoFile.Name);
    }

    [HttpDelete("delete/{fileId}")]
    public async Task<IActionResult> DeleteFile(Guid fileId)
    {
        var toDoFile = await _toDoFileService.GetByIdAsync(fileId);
        if (toDoFile == null)
        {
            return NotFound();
        }

        var isDeleteFromDb = await _toDoFileService.DeleteAsync(fileId);
        if (!isDeleteFromDb) 
        { 
            return BadRequest("Файл не удален"); 
        }

        var isDeleteFromStorage = _fileService.DeleteFile(toDoFile.Path);
        if (!isDeleteFromStorage)
        {
            return BadRequest("Файл не удален");
        }

        return NoContent();
    }
}