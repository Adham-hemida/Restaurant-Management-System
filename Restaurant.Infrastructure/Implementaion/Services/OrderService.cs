using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.Order;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using System.Linq.Dynamic.Core;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class OrderService(IOrderRepository orderRepository) : IOrderService
{
	private readonly IOrderRepository _orderRepository = orderRepository;

	public async Task<Result<OrderResponse>> GetAsync (int orderId, CancellationToken cancellationToken)
	{
		var order=await _orderRepository.GetAsQueryable()
			.Where(x => x.Id == orderId)
			.Include(x => x.OrderItems.Where(oi => oi.IsActive))
			.Include(x=>x.Table)
			.Select(o=> new OrderResponse(
				o.Id,
				o.Name,
				o.Status,
				o.TotalAmount,
				o.IsDelivered,
				o.IsActive,
				o.Table.TableNumber,
				o.OrderItems.Select(oi => new OrderItemMinimalResponse(
					oi.Id,
					oi.Quantity,
					oi.Notes,
					oi.UnitPrice
					)).ToList()
				))
			.SingleOrDefaultAsync(cancellationToken);

		if (order is null)
			return Result.Failure<OrderResponse>(OrderErrors.OrderNotFound);

		return Result.Success(order);
	}

	public async Task<Result<PaginatedList<OrderResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken)
	{
		var query = _orderRepository.GetAsQueryable();
			
		if (!string.IsNullOrEmpty(filters.SearchValue))
		{
			query = query.Where(x => x.Status.Contains(filters.SearchValue)|| x.Name.Contains(filters.SearchValue));
		}

		if (!string.IsNullOrEmpty(filters.SortColumn))
		{
			query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
		}

		var source =  query
			.Include(x => x.OrderItems.Where(oi => oi.IsActive))
			.Include(x => x.Table)
			.AsNoTracking()
			.Select(o => new OrderResponse(
				o.Id,
				o.Name,
				o.Status,
				o.TotalAmount,
				o.IsDelivered,
				o.IsActive,
				o.Table.TableNumber,
				o.OrderItems.Select(oi => new OrderItemMinimalResponse(
					oi.Id,
					oi.Quantity,
					oi.Notes,
					oi.UnitPrice
					)).ToList()
				));
			
		var orders=await PaginatedList<OrderResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);
		return Result.Success(orders);
	}
}
