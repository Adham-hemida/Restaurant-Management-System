namespace RestaurantProject.Application.Features.Table.Queries.Models;
public record GetTableQuery(int TableId) : IRequest<Result<TableResponse>>;
