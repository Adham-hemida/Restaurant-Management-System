using RestaurantProject.Application.Features.MenuItem.Commands.Models;
using RestaurantProject.Domain.Interfaces;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Handlers;
public class ToggleMenuItemStatusCommandHandler(IMenuItemService menuItemService) : IRequestHandler<ToggleMenuItemStatusCommand, Result>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result> Handle(ToggleMenuItemStatusCommand request, CancellationToken cancellationToken)
	{
       return await _menuItemService.ToggleSatausAsync(request.MenuCategoryId, request.MenuItemId, cancellationToken);
	}
}
