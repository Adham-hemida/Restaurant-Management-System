namespace RestaurantProject.Application.Features.OrderItem.Commands.Models;
public record DeleteOrderItemCommand(int OrderId, int MenuItemId, int OrderItemId) : IRequest<Result>;
