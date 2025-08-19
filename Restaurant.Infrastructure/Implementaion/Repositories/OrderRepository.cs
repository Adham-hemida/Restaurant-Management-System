namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
	public OrderRepository(ApplicationDbContext context) : base(context)
	{
	}
}

