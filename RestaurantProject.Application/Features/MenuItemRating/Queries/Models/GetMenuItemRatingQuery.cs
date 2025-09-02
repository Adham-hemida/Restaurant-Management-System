using RestaurantProject.Application.Contracts.MenuItemRating;

namespace RestaurantProject.Application.Features.MenuItemRating.Queries.Models;
public record GetMenuItemRatingQuery(int OrderId, int MenuItemId, int MenuItemRatingId) : IRequest<Result<MenuItemRatingResponse>>;