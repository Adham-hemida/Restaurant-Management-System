using RestaurantProject.Application.Features.MenuItem.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Handlers;
public class AddMenuItemCommandHandler(IMenuItemService menuItemService) : IRequestHandler<AddMenuItemCommand, Result<MenuItemResponse>>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result<MenuItemResponse>> Handle(AddMenuItemCommand request, CancellationToken cancellationToken)
	{
		return await _menuItemService.AddAsync(request.MenuCategoryId, request.MenuItemRequest, cancellationToken);
	}
}
