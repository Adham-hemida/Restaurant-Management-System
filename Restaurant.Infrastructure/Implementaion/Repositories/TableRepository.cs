namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class TableRepository : GenericRepository<Table>, ITableRepository
{
	public TableRepository(ApplicationDbContext context) : base(context)
	{
	}
}

