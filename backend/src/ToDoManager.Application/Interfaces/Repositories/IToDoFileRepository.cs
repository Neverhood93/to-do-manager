using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Interfaces.Repositories;

public interface IToDoFileRepository
{
    Task<IEnumerable<ToDoFile>> GetAllAsync();

    Task<ToDoFile?> GetByIdAsync(Guid id);

    Task<ToDoFile> AddAsync(ToDoFile entity);

    Task<bool> DeleteAsync(ToDoFile entity);
}
