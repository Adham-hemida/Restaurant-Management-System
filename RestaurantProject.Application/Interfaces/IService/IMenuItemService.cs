using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuItem;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuItemService
{
	Task<Result<MenuItemResponse>> GetAsync(int menuCategoryId, int menuItemId, CancellationToken cancellationToken);
	Task<Result<MenuItemWithImagesResponse>> GetMenuItemWithImagesAsync(int menuCategoryId, int menuItemId, CancellationToken cancellationToken);
	Task<Result<PaginatedList<MenuItemWithImagesResponse>>> GetAllAsync(int menuCategoryId, RequestFilters filters, CancellationToken cancellationToken);
	Task<Result<MenuItemResponse>> AddAsync(int menuCategoryId, MenuItemRequest request, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(int menuCategoryId, int menuItemId, MenuItemRequest request, CancellationToken cancellationToken);
	Task<Result> ChangePriceAsync(int menuCategoryId, int menuItemId, ChangePriceRequest request, CancellationToken cancellationToken);
	Task<Result> ToggleSatausAsync(int menuCategoryId, int menuItemId, CancellationToken cancellationToken = default);
}
