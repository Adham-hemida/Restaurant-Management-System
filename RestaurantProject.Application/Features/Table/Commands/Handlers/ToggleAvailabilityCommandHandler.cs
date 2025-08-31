using RestaurantProject.Application.Features.Table.Commands.Models;

namespace RestaurantProject.Application.Features.Table.Commands.Handlers;
public class ToggleAvailabilityCommandHandler(ITableService tableService) : IRequestHandler<ToggleAvailabilityCommand, Result>
{
	private readonly ITableService _tableService = tableService;

	public async Task<Result> Handle(ToggleAvailabilityCommand request, CancellationToken cancellationToken)
	{
		return await _tableService.ToggleAvailabilityAsync(request.TableId, cancellationToken);
	}
}
