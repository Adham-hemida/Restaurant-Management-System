namespace RestaurantProject.Application.Features.Order.Queries.Models;
public record GetByTableCommand(int TableId) : IRequest<Result<IEnumerable<OrderResponse>>>;
