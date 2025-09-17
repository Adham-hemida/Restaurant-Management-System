using RestaurantProject.Application.Contracts.Dashboard;
using RestaurantProject.Application.Features.Dashboard.Queries.Models;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Handlers;
public class GetTopMenuItemsQueryHandler(IDashboardService dashboardService) : IRequestHandler<GetTopMenuItemsQuery, Result<IEnumerable<TopMenuItemResponse>>>
{
	private readonly IDashboardService _dashboardService = dashboardService;

	public async Task<Result<IEnumerable<TopMenuItemResponse>>> Handle(GetTopMenuItemsQuery request, CancellationToken cancellationToken)
	{
		return await _dashboardService.GetTopMenuItemsAsync(request.Date, cancellationToken);
	}
}
