namespace RestaurantProject.Application.Features.MenuItem.Commands.Models;
public record AddMenuItemCommand(int MenuCategoryId,MenuItemRequest MenuItemRequest): IRequest<Result<MenuItemResponse>>;

