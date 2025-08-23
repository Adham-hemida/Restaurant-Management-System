namespace RestaurantProject.Application.Features.MenuCategory.Queries.Models;
public record GetMenuCategoryByIdQuery(int Id) : IRequest<Result<MenuCategoryResponse>>;
