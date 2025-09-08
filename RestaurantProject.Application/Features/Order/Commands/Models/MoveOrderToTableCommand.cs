namespace RestaurantProject.Application.Features.Order.Commands.Models;
public record MoveOrderToTableCommand(int OrderId, int NewTableId) : IRequest<Result>;
