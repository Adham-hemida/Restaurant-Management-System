namespace RestaurantProject.Application.Features.MenuCategory.Queries.Models;

public record GetMenuCategoryByIdQuery(int id) : IRequest<Result<MenuCategoryResponse>>;
