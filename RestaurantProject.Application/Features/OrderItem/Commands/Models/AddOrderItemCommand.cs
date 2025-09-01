namespace RestaurantProject.Application.Features.OrderItem.Commands.Models;
public record AddOrderItemCommand(int OrderId,int MenuItemId, AddOrderItemRequest AddOrderItemRequest) : IRequest<Result<OrderItemResponse>>;

