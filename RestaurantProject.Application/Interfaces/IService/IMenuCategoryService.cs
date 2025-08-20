using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuCategoryService
{
	Task<Result<MenuCategoryResponse>> CreateAsync(MenuCategoryRequest request, CancellationToken cancellationToken);
}
