namespace RestaurantProject.Application.Features.OrderItem.Commands.Models;
public record DeleteAllOrderItemsCommand(int OrderId) : IRequest<Result>;
