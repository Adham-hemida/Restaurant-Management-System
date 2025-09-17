using Microsoft.EntityFrameworkCore;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Dashboard;
using RestaurantProject.Application.Interfaces.IService;
using static RestaurantProject.Infrastructure.Implementaion.Services.DashboardService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;

	public class DashboardService(IInvoiceRepository invoiceRepository,
		IOrderRepository orderRepository,
		IOrderItemRepository orderItemRepository) : IDashboardService
{
		private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;
	private readonly IOrderRepository _orderRepository = orderRepository;
	private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;

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
	
	public async Task<Result<IEnumerable<OrderStatusCountResponse>>> GetDailyOrdersByStatusAsync(DateTime date, CancellationToken cancellationToken)
		{
			  var startOfDay = date.Date;
			var endOfDay = startOfDay.AddDays(1);

			var response = await _orderRepository.GetAsQueryable()
				.AsNoTracking()
				.Where(o => o.CreatedOn>= startOfDay && o.CreatedOn< endOfDay)
				.GroupBy(o => o.Status)
				.Select(g => new OrderStatusCountResponse
				(g.Key,
				g.Count())
					).ToListAsync(cancellationToken);

		return Result.Success<IEnumerable<OrderStatusCountResponse>>(response);
		}

	public async Task<Result<IEnumerable<TopMenuItemResponse>>> GetTopMenuItemsAsync(DateTime date, CancellationToken cancellationToken)
	{
		var startOfDay = date.Date;
		var endOfDay = startOfDay.AddDays(1);

          //هجيب البيانات ال انا عايزها
		var orderItems = await _orderItemRepository.GetAsQueryable()
			.AsNoTracking()
			.Where(oi => oi.Order.CreatedOn >= startOfDay && oi.Order.CreatedOn < endOfDay)
			.Select(oi => new
			{
				MenuItemName = oi.MenuItem.Name,
				Quantity = oi.Quantity
			})
			.ToListAsync(cancellationToken);

		//بقي Groupby  هعمل
		var topItems = orderItems
			.GroupBy(oi => oi.MenuItemName)
			.Select(g => new TopMenuItemResponse(
				g.Key,
				g.Sum(oi => oi.Quantity)
			))
			.OrderByDescending(x => x.QuantitySold)
			.Take(5)
			.ToList();

		return Result.Success<IEnumerable<TopMenuItemResponse>>(topItems);
	}



}

