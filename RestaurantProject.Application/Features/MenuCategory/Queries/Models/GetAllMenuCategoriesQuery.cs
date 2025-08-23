namespace RestaurantProject.Application.Features.MenuCategory.Queries.Models;
public record GetAllMenuCategoriesQuery() : IRequest<IEnumerable<MenuCategoryResponse1>>;
