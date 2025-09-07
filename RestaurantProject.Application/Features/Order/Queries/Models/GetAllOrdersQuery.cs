using RestaurantProject.Application.Contracts.Common;

namespace RestaurantProject.Application.Features.Order.Queries.Models;
public record GetAllOrdersQuery(RequestFilters RequestFilters) : IRequest<Result<PaginatedList<OrderResponse>>>;
