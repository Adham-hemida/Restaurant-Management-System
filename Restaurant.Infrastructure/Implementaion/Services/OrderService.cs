using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.Order;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Consts;
using RestaurantProject.Domain.Entites;
using System.Linq.Dynamic.Core;
using System.Security.Cryptography.Xml;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class OrderService(IOrderRepository orderRepository,
	ITableRepository tableRepository,
	IMenuItemRepository menuItemRepository,
	IOrderItemRepository orderItemRepository
	) : IOrderService
{
	private readonly IOrderRepository _orderRepository = orderRepository;
	private readonly ITableRepository _tableRepository = tableRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;
	private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;

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

	public async Task<Result<OrderResponse>> AddAsync(OrderRequest request, CancellationToken cancellationToken)
	{
		var table = await _tableRepository.GetByIdAsync(request.TableId, cancellationToken);

		if (table is null)
			return Result.Failure<OrderResponse>(TableErrors.TableNotFound);

		if(table.Status != TableStatus.Available)
			return Result.Failure<OrderResponse>(TableErrors.TableNotAvailable);

		var order = new Order
		{
			Name = request.Name,
			TableId = request.TableId,
			OrderItems = new List<OrderItem>()
		};

		foreach (var item in request.OrderItems)
		{
			var menuItem = await _menuItemRepository
				.GetAsQueryable()
				.Where(x => x.Id == item.MenuItemId && x.IsActive)
				.SingleOrDefaultAsync(cancellationToken);

			if (menuItem is null)
				continue;

			var orderItem = new OrderItem
			{
				MenuItemId = item.MenuItemId,
				Quantity = item.Quantity,
				UnitPrice = menuItem.Price,
				Notes = item.Notes,
				Discount = item.Discount,
				TotalPrice = (decimal)item.Quantity * menuItem.Price * (1 - ((decimal)(item.Discount ?? 0) / 100))
			};

			order.OrderItems.Add(orderItem);
			order.TotalAmount += orderItem.TotalPrice;
		}

		if (!order.OrderItems.Any())
		{
			order.IsActive = false;
			return Result.Failure<OrderResponse>(OrderItemErrors.NoOrderItemsFound);
		}

		await _orderRepository.AddAsync(order, cancellationToken);
		var response = new OrderResponse(order.Id, order.Name, order.Status, order.TotalAmount, order.IsDelivered, order.IsActive, table.TableNumber, order.OrderItems.Select(oi => new OrderItemMinimalResponse(oi.Id, oi.Quantity, oi.Notes, oi.UnitPrice)).ToList());
		return Result.Success(response);
	}
}
