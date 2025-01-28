using Microsoft.EntityFrameworkCore;
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Domain.Entities;

namespace ToDoManager.Infrastructure.Repositories;

public class ToDoFileRepository : IToDoFileRepository
{

    protected readonly DatabaseContext Context;
    private readonly DbSet<ToDoFile> _dbSet;

    public ToDoFileRepository(DatabaseContext context)
    {
        Context = context;
        _dbSet = Context.Set<ToDoFile>();
    }

    public virtual async Task<IEnumerable<ToDoFile>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<ToDoFile?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
    }

    public virtual async Task<ToDoFile> AddAsync(ToDoFile entity)
    {
        await _dbSet.AddAsync(entity);
        await Context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<bool> DeleteAsync(ToDoFile entity)
    {
        _dbSet.Remove(entity);
        await Context.SaveChangesAsync();
        return true;
    }
}