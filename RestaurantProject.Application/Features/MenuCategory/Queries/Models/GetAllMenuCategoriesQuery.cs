using RestaurantProject.Application.Contracts.Common;

namespace RestaurantProject.Application.Features.MenuCategory.Queries.Models;
public record GetAllMenuCategoriesQuery(RequestFilters Filters) : IRequest<Result<PaginatedList<MenuCategoryResponse>>>;
