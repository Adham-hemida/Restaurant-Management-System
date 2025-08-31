namespace RestaurantProject.Application.Features.Table.Queries.Models;
public record GetAllTablesQuery():IRequest<Result<IEnumerable<TableResponse>>>;
