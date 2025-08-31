using RestaurantProject.Application.Features.Table.Commands.Models;

namespace RestaurantProject.Application.Features.Table.Commands.Handlers;
public class UpdateTableCommandHandlers(ITableService tableService) : IRequestHandler<UpdateTableCommand, Result>
{
	private readonly ITableService _tableService = tableService;

	public async Task<Result> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
	{
		return await _tableService.UpdateAsync(request.TableId, request.UpdateTableRequest, cancellationToken);
	}
}
