using RestaurantProject.Application.Contracts.MenuItem;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuItemService
{
	Task<Result<MenuItemResponse>> GetAsync(int menuCategoryId, int menuItemId, CancellationToken cancellationToken);
	Task<Result<MenuItemWithImagesResponse>> GetMenuItemWithImagesAsync(int menuCategoryId, int menuItemId, CancellationToken cancellationToken);

}
