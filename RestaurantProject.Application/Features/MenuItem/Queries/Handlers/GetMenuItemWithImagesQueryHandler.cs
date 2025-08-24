using RestaurantProject.Application.Features.MenuItem.Queries.Models;

namespace RestaurantProject.Application.Features.MenuItem.Queries.Handlers;
public class GetMenuItemWithImagesQueryHandler(IMenuItemService menuItemService) : IRequestHandler<GetMenuItemWithImagesQuery, Result<MenuItemWithImagesResponse>>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result<MenuItemWithImagesResponse>> Handle(GetMenuItemWithImagesQuery request, CancellationToken cancellationToken)
	{
		return await _menuItemService.GetMenuItemWithImagesAsync(request.MenuCategoryId, request.MenuItemId, cancellationToken);
	}
}
