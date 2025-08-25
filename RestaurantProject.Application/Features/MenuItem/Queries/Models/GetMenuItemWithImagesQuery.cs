namespace RestaurantProject.Application.Features.MenuItem.Queries.Models;
public record GetMenuItemWithImagesQuery(int MenuCategoryId, int MenuItemId) : IRequest<Result<MenuItemWithImagesResponse>>;
