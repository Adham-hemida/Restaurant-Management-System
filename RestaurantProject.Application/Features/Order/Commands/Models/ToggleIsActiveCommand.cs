namespace RestaurantProject.Application.Features.Order.Commands.Models;
public record ToggleIsActiveCommand(int OrderId) : IRequest<Result>;
