using RestaurantProject.Application.Contracts.MenuItemRating;

namespace RestaurantProject.Application.Features.MenuItemRating.Commands.Models;
public record AddMenuItemRatingCommand(int OrderId, int MenuItemId, MenuItemRatingRequest MenuItemRatingRequest) : IRequest<Result<MenuItemRatingResponse>>;
