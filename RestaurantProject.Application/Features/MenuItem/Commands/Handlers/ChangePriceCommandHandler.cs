using RestaurantProject.Application.Features.MenuItem.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Handlers;
public class ChangePriceCommandHandler(IMenuItemService menuItemService) : IRequestHandler<ChangePriceCommand, Result>
{
	private readonly IMenuItemService _menuItemService = menuItemService;

	public async Task<Result> Handle(ChangePriceCommand request, CancellationToken cancellationToken)
	{
		return await _menuItemService.ChangePriceAsync(request.MenuCategoryId, request.MenuItemId, request.ChangePriceRequest, cancellationToken);
	}
}
