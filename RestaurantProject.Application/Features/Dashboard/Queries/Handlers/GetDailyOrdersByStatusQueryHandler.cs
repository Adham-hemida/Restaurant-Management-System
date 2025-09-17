using RestaurantProject.Application.Contracts.Dashboard;
using RestaurantProject.Application.Features.Dashboard.Queries.Models;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Handlers;
public class GetDailyOrdersByStatusQueryHandler(IDashboardService dashboardService) : IRequestHandler<GetDailyOrdersByStatusQuery, Result<IEnumerable<OrderStatusCountResponse>>>
{
	private readonly IDashboardService _dashboardService = dashboardService;

	public async Task<Result<IEnumerable<OrderStatusCountResponse>>> Handle(GetDailyOrdersByStatusQuery request, CancellationToken cancellationToken)
	{
		return await _dashboardService.GetDailyOrdersByStatusAsync(request.Date, cancellationToken);
	}

}
