using ToDoManager.Domain.Entities;

namespace ToDoManager.Application.Interfaces.Services;

public interface IToDoService
{
    Task<IEnumerable<ToDo>> GetAllAsync();
    Task<ToDo?> GetByIdAsync(int id);
    Task<ToDo> CreateAsync(ToDo todo);
    Task<bool> UpdateAsync(ToDo todo);
    Task<bool> DeleteAsync(int id);
}
