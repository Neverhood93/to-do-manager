using ToDoManager.Domain.Shared;

namespace ToDoManager.Application.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

    Task<T> UpdateAsync(T entity, CancellationToken cancellationToken = default);

    Task<T> DeleteAsync(T entity, CancellationToken cancellationToken = default);

    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
}
