using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Features.MenuItemRating.Queries.Models;

namespace RestaurantProject.Application.Features.MenuItemRating.Queries.Handler;
public class GetAllMenuItemsRatingQueryHandler(IMenuItemRatingService menuItemRatingService) : IRequestHandler<GetAllMenuItemsRatingQuery, Result<PaginatedList<MenuItemRatingResponse>>>
{
	private readonly IMenuItemRatingService _menuItemRatingService = menuItemRatingService;

	public async Task<Result<PaginatedList<MenuItemRatingResponse>>> Handle(GetAllMenuItemsRatingQuery request, CancellationToken cancellationToken)
	{
		return await _menuItemRatingService.GetAllAsync(request.MenuItemId, request.Filters,cancellationToken);
	}
}
