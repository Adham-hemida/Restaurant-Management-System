namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class MenuItemRepository : GenericRepository<MenuItem>, IMenuItemRepository
{
	public MenuItemRepository(ApplicationDbContext context) : base(context)
	{
	}
}

