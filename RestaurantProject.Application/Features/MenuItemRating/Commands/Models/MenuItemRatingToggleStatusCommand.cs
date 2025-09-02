namespace RestaurantProject.Application.Features.MenuItemRating.Commands.Models;
public record MenuItemRatingToggleStatusCommand(int OrderId,int MenuItemId,int MenuItemRatingId): IRequest<Result>;
