using RestaurantProject.Application.Contracts.Dashboard;
using RestaurantProject.Application.Features.Dashboard.Queries.Models;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Handlers;
public class GetDailyRevenueQueryHandler(IDashboardService dashboardService) : IRequestHandler<GetDailyRevenueQuery, Result<DailyRevenueResponse>>
{
	public async Task<Result<DailyRevenueResponse>> Handle(GetDailyRevenueQuery request, CancellationToken cancellationToken)
	{
		return await dashboardService.GetDailyRevenueAsync(request.Date, cancellationToken);
	}
}
