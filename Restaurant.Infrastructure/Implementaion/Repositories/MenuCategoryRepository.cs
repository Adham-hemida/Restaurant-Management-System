namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class MenuCategoryRepository: GenericRepository<MenuCategory>, IMenuCategoryRepository
{
	public MenuCategoryRepository(ApplicationDbContext context) : base(context)
	{
	}
}

