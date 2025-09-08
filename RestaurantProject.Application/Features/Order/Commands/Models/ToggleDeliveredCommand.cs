namespace RestaurantProject.Application.Features.Order.Commands.Models;
public record ToggleDeliveredCommand(int OrderId) : IRequest<Result>;
