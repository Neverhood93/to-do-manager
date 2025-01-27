using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using ToDoManager.API.Models;
using ToDoManager.Application.Interfaces.Services;
using ToDoManager.Domain.Entities;

namespace ToDoManager.API.Controllers;

[ApiController]
[Route("api/todos")]
public class ToDoController : ControllerBase
{
    private readonly IToDoService _service;

    public ToDoController(IToDoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetById(Guid id)
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
            CreatedOn = DateTime.UtcNow,
        });

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:Guid}")]
    public async Task<IActionResult> Update(Guid id, CreateUpdateToDoRequest request)
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

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
