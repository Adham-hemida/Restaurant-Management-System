using RestaurantProject.Application.Contracts.MenuItem;

namespace RestaurantProject.Application.Contracts.MenuCategory;
public record MenuCategoryWithMenuItemsResponse(
	 int Id,
	 string Name,
	 string Description,
	 IEnumerable<MenuItemResponse> MenuItems
	);
