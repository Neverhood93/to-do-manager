using Microsoft.EntityFrameworkCore;
using ToDoManager.Application.Interfaces.Repositories;
using ToDoManager.Domain.Shared;

namespace ToDoManager.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DatabaseContext Context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DatabaseContext context)
    {
        Context = context;
        _dbSet = Context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _dbSet.AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public virtual async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Update(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public virtual async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken = default)
    {
        _dbSet.Remove(entity);
        await Context.SaveChangesAsync(cancellationToken);
        return true;
    }




}
