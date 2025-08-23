namespace RestaurantProject.Application.Features.MenuCategory.Queries.Models;

public record GetMenuCategoryWithMenuItemsQuery(int Id) : IRequest<Result<MenuCategoryWithMenuItemsResponse>>;
