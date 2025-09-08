namespace RestaurantProject.Application.Features.Order.Commands.Models;
public record AddOrderCommand(OrderRequest OrderRequest) : IRequest<Result<OrderResponse>>;