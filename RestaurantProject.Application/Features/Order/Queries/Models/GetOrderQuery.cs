namespace RestaurantProject.Application.Features.Order.Queries.Models;
public record GetOrderQuery(int OrderId) : IRequest<Result<OrderResponse>>;
