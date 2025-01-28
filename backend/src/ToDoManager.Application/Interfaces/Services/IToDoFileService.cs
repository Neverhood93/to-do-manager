using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Interfaces.Services;

public interface IToDoFileService
{
    Task<ToDoFile?> CreateAsync(ToDoFile toDoFile, int todoid);

    Task<ToDoFile?> GetByIdAsync(Guid toDoFileId);

    Task<bool> DeleteAsync(Guid toDoFileId);
}
