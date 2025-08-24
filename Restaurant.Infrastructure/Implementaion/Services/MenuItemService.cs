using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class MenuItemService(IMenuCategoryRepository menuCategoryRepository,IMenuItemRepository menuItemRepository) : IMenuItemService
{
	private readonly IMenuCategoryRepository _menuCategoryRepository = menuCategoryRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

	public async Task<Result<MenuItemResponse>> GetAsync(int menuCategoryId,int menuItemId,CancellationToken cancellationToken)
	{
		var menuCategoryIsExist=await _menuCategoryRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure<MenuItemResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		var menuItem = await _menuItemRepository.GetAsQueryable()
			.Where( x => x.Id == menuItemId && x.IsActive)
			.AsNoTracking()
			.ProjectToType<MenuItemResponse>()
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem is null)
			return Result.Failure<MenuItemResponse>(MenuItemErrors.MenuItemNotFound);

		return Result.Success(menuItem);
	}
}
