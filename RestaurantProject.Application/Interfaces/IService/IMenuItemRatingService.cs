using RestaurantProject.Application.Contracts.MenuItemRating;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IMenuItemRatingService
{
	Task<Result<MenuItemRatingResponse>> AddAsync(int orderId, int menuItemId, MenuItemRatingRequest request, CancellationToken cancellationToken);
	Task<Result<MenuItemRatingResponse>> GetAsync(int orderId, int menuItemId, int menuItemRatingId, CancellationToken cancellationToken);

}
