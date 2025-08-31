using RestaurantProject.Application.Contracts.Common;

namespace RestaurantProject.Application.Features.Table.Queries.Models;
public record GetAllTablesQuery(RequestFilters RequestFilters):IRequest<Result<PaginatedList<TableResponse>>>;
