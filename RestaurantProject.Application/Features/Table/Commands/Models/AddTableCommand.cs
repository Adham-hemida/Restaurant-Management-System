namespace RestaurantProject.Application.Features.Table.Commands.Models;
public record AddTableCommand(AddTableRequest AddTableRequest): IRequest<Result<TableResponse>>;
