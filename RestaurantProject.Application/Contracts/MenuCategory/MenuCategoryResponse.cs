using RestaurantProject.Application.Contracts.MenuItem;

namespace RestaurantProject.Application.Contracts.MenuCategory;
public record MenuCategoryResponse(
	 int Id,
	 string Name,
	 string Description,
	 IEnumerable<MenuItemResponse> MenuItems
	);
