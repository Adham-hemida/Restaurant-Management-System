namespace RestaurantProject.Application.Features.OrderItem.Commands.Models;
public record UpdateOrderItemCommand(int OrderId, int MenuItemId, int OrderItemId, AddOrderItemRequest AddOrderItemRequest) : IRequest<Result>;
