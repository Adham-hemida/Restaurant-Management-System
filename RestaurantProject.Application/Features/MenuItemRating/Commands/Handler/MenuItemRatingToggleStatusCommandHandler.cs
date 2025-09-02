using RestaurantProject.Application.Features.MenuItemRating.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItemRating.Commands.Handler;
public class MenuItemRatingToggleStatusCommandHandler(IMenuItemRatingService menuItemRatingService) : IRequestHandler<MenuItemRatingToggleStatusCommand, Result>
{
	private readonly IMenuItemRatingService _menuItemRatingService = menuItemRatingService;

	public async Task<Result> Handle(MenuItemRatingToggleStatusCommand request, CancellationToken cancellationToken)
	{
		return await _menuItemRatingService.ToggleStatusAsync(request.OrderId,request.MenuItemId,request.MenuItemRatingId,cancellationToken);
	}
}
