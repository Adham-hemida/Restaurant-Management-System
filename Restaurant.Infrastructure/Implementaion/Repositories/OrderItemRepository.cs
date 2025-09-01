namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
{
	public OrderItemRepository(ApplicationDbContext context) : base(context)
	{
	}
}
