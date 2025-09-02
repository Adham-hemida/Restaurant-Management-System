using RestaurantProject.Application.Contracts.MenuItemRating;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuItemRatingService
{
	Task<Result<MenuItemRatingResponse>> AddAsync(int orderId, int menuItemId, MenuItemRatingRequest request, CancellationToken cancellationToken);
}
