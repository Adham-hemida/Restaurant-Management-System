using RestaurantProject.Application.Features.MenuItem.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Handlers;
public class UpdateMenuItemCommandHandler(IMenuItemService menuItemService) : IRequestHandler<UpdateMenuItemCommand, Result>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result> Handle(UpdateMenuItemCommand request, CancellationToken cancellationToken)
	{
		return await _menuItemService.UpdateAsync(request.MenuCategoryId, request.MenuItemId, request.MenuItemRequest, cancellationToken);
	}
}
