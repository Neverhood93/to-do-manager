using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure.Repositories;

public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
{
    public ToDoRepository(DatabaseContext context) : base(context)
    {
    }
}
