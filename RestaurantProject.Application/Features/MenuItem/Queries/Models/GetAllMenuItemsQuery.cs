using RestaurantProject.Application.Contracts.Common;

namespace RestaurantProject.Application.Features.MenuItem.Queries.Models;
public record GetAllMenuItemsQuery(int MenuCategoryId, RequestFilters Filters) : IRequest<Result<PaginatedList<MenuItemWithImagesResponse>>>;
