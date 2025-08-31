using RestaurantProject.Application.Features.Table.Queries.Models;

namespace RestaurantProject.Application.Features.Table.Queries.Handlers;
public class GetAllTablesQueryHandler(ITableService tableService) : IRequestHandler<GetAllTablesQuery, Result<IEnumerable<TableResponse>>>
{
	private readonly ITableService _tableService = tableService;

	public async Task<Result<IEnumerable<TableResponse>>> Handle(GetAllTablesQuery request, CancellationToken cancellationToken)
	{
		return await _tableService.GetAllAsync(cancellationToken);
	}
}
