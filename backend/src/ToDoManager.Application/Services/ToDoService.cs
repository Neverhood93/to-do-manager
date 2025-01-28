using System.Security.Principal;
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Application.Interfaces.Services;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Services;

public class ToDoService : IToDoService
{
    private readonly IToDoRepository _repository;

    public ToDoService(IToDoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ToDo>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<ToDo?> GetByIdAsync(int id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<ToDo> CreateAsync(ToDo todo)
    {
        return await _repository.AddAsync(todo);
    }

    public async Task<bool> UpdateAsync(ToDo todo)
    {
        return await _repository.UpdateAsync(todo);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        ToDo? entity = await GetByIdAsync(id);
        if (entity == null)
        {
            return false;
        }

        return await _repository.DeleteAsync(entity);
    }
}
