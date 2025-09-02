using Azure.Core;
using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Consts;
using RestaurantProject.Domain.Entites;
using System.Runtime.CompilerServices;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class OrderItemService(IOrderItemRepository orderItemRepository,
	IOrderRepository orderRepository,
	IMenuItemRepository menuItemRepository ) : IOrderItemService

{
	private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;
	private readonly IOrderRepository _orderRepository = orderRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;


	public async Task<Result<OrderItemResponse>> GetAsync(int orderId, int menuItemId, int orderItemId, CancellationToken cancellationToken)
	{
		var orderIsExist = await _orderRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == orderId && x.IsActive, cancellationToken);

		if (!orderIsExist)
			return Result.Failure<OrderItemResponse>(OrderErrors.OrderNotFound);

		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuItemId && x.IsActive, cancellationToken);

		if (!menuItemIsExist)
			return Result.Failure<OrderItemResponse>(MenuItemErrors.MenuItemNotFound);



		var orderItem = await _orderItemRepository.GetAsQueryable()
			.Where(x => x.Id == orderItemId && x.OrderId==orderId && x.MenuItemId == menuItemId)
			.AsNoTracking()
			.ProjectToType<OrderItemResponse>()
			.SingleOrDefaultAsync(cancellationToken);

		if (orderItem is null)
			return Result.Failure<OrderItemResponse>(OrderItemErrors.OrderNotFound);

		return Result.Success(orderItem);
	}
	public async Task<Result<IEnumerable<OrderItemResponse>>> GetAllAsync(int orderId, CancellationToken cancellationToken)
	{
		var orderIsExist = await _orderRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == orderId && x.IsActive, cancellationToken);

		if (!orderIsExist)
			return Result.Failure<IEnumerable<OrderItemResponse>>(OrderErrors.OrderNotFound);

		var orderItems = await _orderItemRepository.GetAsQueryable()
			.Where(x => x.OrderId == orderId)
			.AsNoTracking()
			.ProjectToType<OrderItemResponse>()
			.ToListAsync(cancellationToken);

		if (!orderItems.Any())
			return Result.Failure<IEnumerable<OrderItemResponse>>(OrderItemErrors.NoOrderItemsFound);

		return Result.Success<IEnumerable<OrderItemResponse>>(orderItems);
	}

	public async Task<Result<OrderItemResponse>> AddAsync(int orderId, int menuItemId, AddOrderItemRequest request, CancellationToken cancellationToken)
	{
	   var order=await _orderRepository.GetByIdAsync(orderId, cancellationToken);

		if (order is null)
			return Result.Failure<OrderItemResponse>(OrderErrors.OrderNotFound);

		if(order.Status!=OrderStatus.Pending)
			return Result.Failure<OrderItemResponse>(OrderErrors.OrderCannotBeModified);

		var menuItem = await _menuItemRepository.GetByIdAsync(menuItemId, cancellationToken);

		if (menuItem is null)
			return Result.Failure<OrderItemResponse>(MenuItemErrors.MenuItemNotFound);

		var orderItem=request.Adapt<OrderItem>();
		orderItem.UnitPrice = menuItem.Price;
		orderItem.TotalPrice = CalculateTotalPrice(orderItem.Quantity, orderItem.UnitPrice, request.Discount);

		orderItem.OrderId = orderId;
		orderItem.MenuItemId = menuItemId;
		order.TotalAmount += orderItem.TotalPrice;

		await _orderItemRepository.AddAsync(orderItem, cancellationToken);
		await _orderRepository.UpdateAsync(order, cancellationToken);

		return Result.Success(orderItem.Adapt<OrderItemResponse>());

	}
	public async Task<Result> UpdateAsync(int orderId, int menuItemId,int orderItemId, AddOrderItemRequest request, CancellationToken cancellationToken)
	{
		var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);

		if (order is null)
			return Result.Failure(OrderErrors.OrderNotFound);

		if (order.Status != OrderStatus.Pending)
			return Result.Failure(OrderErrors.OrderCannotBeModified);

		var menuItem = await _menuItemRepository.GetByIdAsync(menuItemId, cancellationToken);

		if (menuItem is null)
			return Result.Failure(MenuItemErrors.MenuItemNotFound);

        var orderItem=await _orderItemRepository.GetAsQueryable()
			.Where(x => x.Id == orderItemId && x.OrderId == orderId && x.MenuItemId == menuItemId)
			.SingleOrDefaultAsync(cancellationToken);

		if (orderItem is null)
			return Result.Failure(OrderItemErrors.OrderNotFound);

		order.TotalAmount -= orderItem.TotalPrice;
		orderItem.Quantity = request.Quantity;

		orderItem.Discount = request.Discount;
		orderItem.Notes = request.Notes;
		
		orderItem.TotalPrice = CalculateTotalPrice(orderItem.Quantity, orderItem.UnitPrice, request.Discount);
		order.TotalAmount += orderItem.TotalPrice;
	
		await _orderItemRepository.UpdateAsync(orderItem, cancellationToken);
		await _orderRepository.UpdateAsync(order, cancellationToken);
		return Result.Success(orderItem.Adapt<OrderItemResponse>());

	}

	public async Task<Result> DeleteAsync (int orderId, int menuItemId, int orderItemId, CancellationToken cancellationToken)
	{
		var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
		if (order is null)
			return Result.Failure(OrderErrors.OrderNotFound);
		
		if (order.Status != OrderStatus.Pending)
			return Result.Failure(OrderErrors.OrderCannotBeModified);
		
		var menuItem = await _menuItemRepository.GetByIdAsync(menuItemId, cancellationToken);
		if (menuItem is null)
			return Result.Failure(MenuItemErrors.MenuItemNotFound);
		
		var orderItem = await _orderItemRepository.GetAsQueryable()
			.Where(x => x.Id == orderItemId && x.OrderId == orderId && x.MenuItemId == menuItemId)
			.SingleOrDefaultAsync(cancellationToken);
	
		if (orderItem is null)
			return Result.Failure(OrderItemErrors.OrderNotFound);
	
		order.TotalAmount -= orderItem.TotalPrice;
		
		await _orderItemRepository.DeleteAsync(orderItem, cancellationToken);
		await _orderRepository.UpdateAsync(order, cancellationToken);
		return Result.Success();
	}

	public async Task<Result> DeleteAllAsync(int orderId, CancellationToken cancellationToken)
	{
		var order = await _orderRepository.GetByIdAsync(orderId, cancellationToken);
		if (order is null)
			return Result.Failure(OrderErrors.OrderNotFound);
	
		if (order.Status != OrderStatus.Pending)
			return Result.Failure(OrderErrors.OrderCannotBeModified);
	
		var orderItems = await _orderItemRepository.GetAsQueryable()
			.Where(x => x.OrderId == orderId)
			.ToListAsync(cancellationToken);
	
		if (!orderItems.Any())
			return Result.Failure(OrderItemErrors.NoOrderItemsFound);
		order.TotalAmount = 0;
	
		await _orderItemRepository.DeleteRange(orderItems, cancellationToken);
		await _orderRepository.UpdateAsync(order, cancellationToken);
		return Result.Success();
	}

	private decimal CalculateTotalPrice(double quantity, decimal unitPrice, double? discount)
	{
		return (decimal)quantity * unitPrice * (1 - ((decimal)(discount ?? 0) / 100));
	}

}
