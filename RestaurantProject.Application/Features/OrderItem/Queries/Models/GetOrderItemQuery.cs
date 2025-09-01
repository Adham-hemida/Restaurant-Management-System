namespace RestaurantProject.Application.Features.OrderItem.Queries.Models;
public record GetOrderItemQuery(int OrderId, int MenuItemId, int OrderItemId) : IRequest<Result<OrderItemResponse>>;

