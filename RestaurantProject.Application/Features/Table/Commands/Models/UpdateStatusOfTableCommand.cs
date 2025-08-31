namespace RestaurantProject.Application.Features.Table.Commands.Models;
public record UpdateStatusOfTableCommand(int TableId, string Status) : IRequest<Result>;

