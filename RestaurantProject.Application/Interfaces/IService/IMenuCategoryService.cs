using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuCategoryService
{
	Task<Result<MenuCategoryResponse>> CreateAsync(MenuCategoryRequest request, CancellationToken cancellationToken);
	Task<Result<MenuCategoryResponse>> GetAsync(int id, CancellationToken cancellationToken);
	Task<IEnumerable<MenuCategoryResponse1>> GetAllAsync(CancellationToken cancellationToken);
}
