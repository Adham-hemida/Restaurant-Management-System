namespace RestaurantProject.Application.Features.Order.Commands.Models;
public record UpdateStatusOfOrderCommand(int OrderId, UpdateOrderStatusRequest StatusRequest) : IRequest<Result>;
