using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Dashboard;
using RestaurantProject.Application.Interfaces.IService;
using static RestaurantProject.Infrastructure.Implementaion.Services.DashboardService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;

	public class DashboardService(IInvoiceRepository invoiceRepository) : IDashboardService
{
		private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;

		public async Task<Result<DailyRevenueResponse>> GetDailyRevenueAsync(DateTime date, CancellationToken cancellationToken)
		{
			var startOfDay = date.Date;
			var endOfDay = startOfDay.AddDays(1);

			var dailyRevenue = await _invoiceRepository.GetAsQueryable()
				.AsNoTracking()
				.Where(i => i.IsPaid && i.PaidAt >= startOfDay && i.PaidAt < endOfDay)
				.SumAsync(i => (decimal?)(i.ServiceCharge + i.Tax + i.TotalAmount), cancellationToken) ?? 0;

			return Result.Success(new DailyRevenueResponse(dailyRevenue));
		}

	}

