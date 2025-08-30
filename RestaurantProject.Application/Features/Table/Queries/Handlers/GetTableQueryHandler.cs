using RestaurantProject.Application.Features.Table.Queries.Models;

namespace RestaurantProject.Application.Features.Table.Queries.Handlers;
public class GetTableQueryHandler(ITableService tableService) : IRequestHandler<GetTableQuery, Result<TableResponse>>
{
	private readonly ITableService _tableService = tableService;

	public async Task<Result<TableResponse>> Handle(GetTableQuery request, CancellationToken cancellationToken)
	{
		return await _tableService.GetAsync(request.TableId, cancellationToken);
	}
}
