namespace RestaurantProject.Application.Features.MenuItem.Commands.Models;
public record ChangePriceCommand(int MenuCategoryId,int MenuItemId, ChangePriceRequest ChangePriceRequest) : IRequest<Result>;
