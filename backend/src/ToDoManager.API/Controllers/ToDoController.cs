using Microsoft.AspNetCore.Mvc;
using ToDoManager.API.Interfaces;
using ToDoManager.API.Models;
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Application.Interfaces.Services;
using ToDoManager.Domain.Entities;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/todos")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _service;
    private readonly IFileService _fileService;
    private readonly IToDoFileRepository _toDoFileRepository;

    public ToDoController(IToDoService service, 
        IFileService fileService,
        IToDoFileRepository toDoFileRepository)
    {
        _service = service;
        _fileService = fileService;
        _toDoFileRepository = toDoFileRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var todo = await _service.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        return Ok(todo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUpdateToDoRequest request)
    {
        var created = await _service.CreateAsync(new ToDo() { 
            Name = request.Name, 
            StatusId = request.StatusId,
        });

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CreateUpdateToDoRequest request)
    {
        var todo = await _service.GetByIdAsync(id);
        if (todo == null)
        {
            return NotFound();
        }

        todo.Name = request.Name;
        todo.StatusId = request.StatusId;
        todo.ModifiedOn = DateTime.UtcNow;

        var updated = await _service.UpdateAsync(todo);
        if (!updated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var toDoFileCount = await _toDoFileRepository.GetCountToDoFileByIdAsync(id);
        if (toDoFileCount > 0)
        {
            var isDeleteDirectoryFromStorage = _fileService.DeleteDirectory("todo", id);
            if (!isDeleteDirectoryFromStorage)
            {
                return BadRequest("Папка не удалена");
            }
        }

        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }              

        return NoContent();
    }
}
