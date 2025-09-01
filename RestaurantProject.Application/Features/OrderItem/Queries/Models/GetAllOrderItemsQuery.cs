namespace RestaurantProject.Application.Features.OrderItem.Queries.Models;
public record GetAllOrderItemsQuery(int OrderId) : IRequest<Result<IEnumerable<OrderItemResponse>>>;
