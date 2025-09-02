using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Features.MenuItemRating.Queries.Models;

namespace RestaurantProject.Application.Features.MenuItemRating.Queries.Handler;
public class GetMenuItemRatingQueryHandler(IMenuItemRatingService menuItemRatingService) : IRequestHandler<GetMenuItemRatingQuery, Result<MenuItemRatingResponse>>
{
	private readonly IMenuItemRatingService _menuItemRatingService = menuItemRatingService;

	public async Task<Result<MenuItemRatingResponse>> Handle(GetMenuItemRatingQuery request, CancellationToken cancellationToken)
	{
		return await _menuItemRatingService.GetAsync(request.OrderId, request.MenuItemId, request.MenuItemRatingId, cancellationToken);
	}
}
