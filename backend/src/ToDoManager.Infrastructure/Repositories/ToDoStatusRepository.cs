using ToDoManager.Application.Repositories;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure.Repositories;

public class ToDoStatusRepository : BaseRepository<ToDoStatus>, IToDoStatusRepository
{
    public ToDoStatusRepository(DatabaseContext context) : base(context)
    {
    }
}
