using RestaurantProject.Application.Features.MenuItem.Queries.Models;

namespace RestaurantProject.Application.Features.MenuItem.Queries.Handlers;
public class GetMenuItemQueryHandler(IMenuItemService menuItemService) : IRequestHandler<GetMenuItemQuery, Result<MenuItemResponse>>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result<MenuItemResponse>> Handle(GetMenuItemQuery request, CancellationToken cancellationToken)
	{
		return await _menuItemService.GetAsync(request.MenuCategoryId, request.MenuItemId,cancellationToken);
	}
}

