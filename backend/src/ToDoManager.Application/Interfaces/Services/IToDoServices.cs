using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
