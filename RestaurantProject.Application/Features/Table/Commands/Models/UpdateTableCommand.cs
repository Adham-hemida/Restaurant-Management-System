namespace RestaurantProject.Application.Features.Table.Commands.Models;
public record UpdateTableCommand(int TableId,UpdateTableRequest UpdateTableRequest) : IRequest<Result>;
