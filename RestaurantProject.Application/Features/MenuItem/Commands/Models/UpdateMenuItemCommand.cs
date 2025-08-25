namespace RestaurantProject.Application.Features.MenuItem.Commands.Models;
public record UpdateMenuItemCommand(int MenuCategoryId,int MenuItemId, MenuItemRequest MenuItemRequest) : IRequest<Result>;
