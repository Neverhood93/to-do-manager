using Microsoft.EntityFrameworkCore;
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure.Repositories;

public class ToDoRepository : BaseRepository<ToDo>, IToDoRepository
{
    private readonly DatabaseContext _context;

    public ToDoRepository(DatabaseContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<ToDo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.ToDos
            .Include(t => t.Status)
            .Include(t => t.Files)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ToDo> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _context.ToDos
            .Include(t => t.Status)
            .Include(t => t.Files)
            .FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
