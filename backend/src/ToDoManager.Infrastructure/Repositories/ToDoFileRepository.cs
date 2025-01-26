using ToDoManager.Application.Repositories;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure.Repositories;

public class ToDoFileRepository : BaseRepository<ToDoFile>, IToDoFileRepository
{
    public ToDoFileRepository(DatabaseContext context) : base(context)
    {
    }
}