
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Application.Interfaces.Services;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Services;

public class ToDoFileService : IToDoFileService
{
    private readonly IToDoRepository _toDoRepository;
    private readonly IToDoFileRepository _toDoFileRepository;

    public ToDoFileService(IToDoRepository toDoRepository, IToDoFileRepository toDoFileRepository)
    {
        _toDoRepository = toDoRepository;
        _toDoFileRepository = toDoFileRepository;
    }

    public async Task<ToDoFile?> CreateAsync(ToDoFile todoFile, int todoid)
    {
        ToDo? todo = await _toDoRepository.GetByIdAsync(todoid);
        if (todo == null)
        {
            return null;
        }

        todoFile.ToDo = todo;

        return await _toDoFileRepository.AddAsync(todoFile);
    }

    public async Task<ToDoFile?> GetByIdAsync(Guid toDoFileId)
    {
        return await _toDoFileRepository.GetByIdAsync(toDoFileId);
    }

    public async Task<bool> DeleteAsync(Guid toDoFileId)
    {
        ToDoFile? toDoFile = await GetByIdAsync(toDoFileId);
        if (toDoFile == null)
        {
            return false;
        }

        return await _toDoFileRepository.DeleteAsync(toDoFile);
    }
}