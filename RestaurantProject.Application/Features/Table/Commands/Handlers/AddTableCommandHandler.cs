using RestaurantProject.Application.Features.Table.Commands.Models;
using System.Reflection.Metadata.Ecma335;

namespace RestaurantProject.Application.Features.Table.Commands.Handlers;
public class AddTableCommandHandler(ITableService tableService) : IRequestHandler<AddTableCommand, Result<TableResponse>>
{
	private readonly ITableService _tableService = tableService;

	public async Task<Result<TableResponse>> Handle(AddTableCommand request, CancellationToken cancellationToken)
	{
		return await _tableService.AddAsync(request.AddTableRequest, cancellationToken);
	}
}
