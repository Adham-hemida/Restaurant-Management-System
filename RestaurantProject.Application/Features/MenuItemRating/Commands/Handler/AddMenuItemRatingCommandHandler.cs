using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Features.MenuItemRating.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItemRating.Commands.Handler;
public class AddMenuItemRatingCommandHandler(IMenuItemRatingService menuItemRatingService) : IRequestHandler<AddMenuItemRatingCommand, Result<MenuItemRatingResponse>>
{
	private readonly IMenuItemRatingService _menuItemRatingService = menuItemRatingService;

	public async Task<Result<MenuItemRatingResponse>> Handle(AddMenuItemRatingCommand request, CancellationToken cancellationToken)
	{
		return await _menuItemRatingService.AddAsync(request.OrderId, request.MenuItemId, request.MenuItemRatingRequest, cancellationToken);
	}
}
