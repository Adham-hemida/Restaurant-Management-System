using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuItemRating;

namespace RestaurantProject.Application.Features.MenuItemRating.Queries.Models;
public record GetAllMenuItemsRatingQuery(int MenuItemId, RequestFilters Filters) : IRequest<Result<PaginatedList<MenuItemRatingResponse>>>;
