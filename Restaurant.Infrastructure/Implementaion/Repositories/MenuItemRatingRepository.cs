namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class MenuItemRatingRepository :GenericRepository<MenuItemRating>, IMenuItemRatingRepository
{
	public MenuItemRatingRepository(ApplicationDbContext context) : base(context)
	{
	}
}

