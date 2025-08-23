using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuCategoryService
{
	Task<Result<MenuCategoryResponse>> GetAsync(int id, CancellationToken cancellationToken);
	Task<IEnumerable<MenuCategoryResponse>> GetAllAsync(CancellationToken cancellationToken);
	Task<Result<MenuCategoryWithMenuItemsResponse>> GetMenuCategoryWithMenuItemsAsync(int id, CancellationToken cancellationToken);
	Task<Result<MenuCategoryResponse>> CreateAsync(MenuCategoryRequest request, CancellationToken cancellationToken);
	Task<Result<MenuCategoryResponse>> UpdateAsync(int id, MenuCategoryRequest request, CancellationToken cancellationToken);
	Task<Result> ToggleSatausAsync(int id, CancellationToken cancellationToken);

}
