namespace RestaurantProject.Application.Features.MenuItem.Queries.Models;
public record GetMenuItemQuery(int MenuCategoryId,int MenuItemId) : IRequest<Result<MenuItemResponse>>;
