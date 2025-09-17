using RestaurantProject.Application.Contracts.Dashboard;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IDashboardService
{
	Task<Result<DailyRevenueResponse>> GetDailyRevenueAsync(DateTime date, CancellationToken cancellationToken);
}
