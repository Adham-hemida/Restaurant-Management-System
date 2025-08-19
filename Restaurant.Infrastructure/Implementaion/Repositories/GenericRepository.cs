using RestaurantProject.Domain.Repositories;
using RestaurantProject.Infrastructure.Data;
using System.Linq.Expressions;

namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
	private readonly ApplicationDbContext _context;
	public GenericRepository(ApplicationDbContext context)
	{
		_context = context;
		
	}

	public IQueryable<T> GetAsQueryable()
	{
		return _context.Set<T>().AsQueryable();
	}
	public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
	{
		await _context.Set<T>().AddAsync(entity);
		await _context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
	{
		_context.Set<T>().Remove(entity);
		await _context.SaveChangesAsync(cancellationToken);
	}

	public async Task DeleteRange(IEnumerable<T> entities, CancellationToken cancellationToken = default)
	{
		_context.Set<T>().RemoveRange(entities);
		await _context.SaveChangesAsync(cancellationToken);
	}

	public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
	{
		IQueryable<T> query = _context.Set<T>();
		foreach(var include in includes)
		{
			query = query.Include(include);
		}
		return await query.Where(criteria).AsNoTracking().ToListAsync(cancellationToken);

	}

	public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes)
	{
		IQueryable<T> query = _context.Set<T>();
		foreach (var include in includes)
		{
			query = query.Include(include);
		}
		return await query.SingleOrDefaultAsync(criteria, cancellationToken);
	}

	public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
	}



	public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
	{
		return await _context.Set<T>().FindAsync(id, cancellationToken);
	}

	public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
	{
		 _context.Set<T>().Update(entity);
		await _context.SaveChangesAsync(cancellationToken);
	}
}
