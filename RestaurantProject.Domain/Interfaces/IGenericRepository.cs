using System.Linq.Expressions;
using System.Threading;

namespace RestaurantProject.Domain.Repositories;
public interface IGenericRepository<T> where T : class
{
	IQueryable<T> GetAsQueryable();
	Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
	Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
	Task<T> FindAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
	Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria,  CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);
	Task AddAsync(T entity, CancellationToken cancellationToken = default);
	Task UpdateAsync(T entity,CancellationToken cancellationToken = default);
	Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
	Task DeleteRange(IEnumerable<T> entities, CancellationToken cancellationToken = default);
}
