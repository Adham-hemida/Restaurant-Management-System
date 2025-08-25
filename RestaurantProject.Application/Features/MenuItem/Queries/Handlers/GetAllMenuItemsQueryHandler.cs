using RestaurantProject.Application.Features.MenuItem.Queries.Models;

namespace RestaurantProject.Application.Features.MenuItem.Queries.Handlers;
public class GetAllMenuItemsQueryHandler(IMenuItemService menuItemService) : IRequestHandler<GetAllMenuItemsQuery, Result<PaginatedList<MenuItemWithImagesResponse>>>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result<PaginatedList<MenuItemWithImagesResponse>>> Handle(GetAllMenuItemsQuery request, CancellationToken cancellationToken)
	{
		return await _menuItemService.GetAllAsync(request.MenuCategoryId, request.Filters, cancellationToken);
	}
}
