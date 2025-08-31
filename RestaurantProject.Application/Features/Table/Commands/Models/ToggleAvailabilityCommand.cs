namespace RestaurantProject.Application.Features.Table.Commands.Models;
public record ToggleAvailabilityCommand(int TableId) : IRequest<Result>;
