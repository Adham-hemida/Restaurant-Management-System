using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class OrderItemService(IOrderItemRepository orderItemRepository,
	IOrderRepository orderRepository,
	IMenuItemRepository menuItemRepository
	) : IOrderItemService
{
	private readonly IOrderItemRepository _orderItemRepository = orderItemRepository;
	private readonly IOrderRepository _orderRepository = orderRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

	public async Task<Result<OrderItemResponse>> AddAsync(int orderId, int menuItemId, AddOrderItemRequest request, CancellationToken cancellationToken)
	{
	   var order=await _orderRepository.GetByIdAsync(orderId, cancellationToken);

		if (order is null)
			return Result.Failure<OrderItemResponse>(OrderErrors.OrderNotFound);

		var menuItem = await _menuItemRepository.GetByIdAsync(menuItemId, cancellationToken);

		if (menuItem is null)
			return Result.Failure<OrderItemResponse>(MenuItemErrors.MenuItemNotFound);

		var orderItem=request.Adapt<OrderItem>();
		orderItem.UnitPrice = menuItem.Price;
		orderItem.TotalPrice = (decimal)orderItem.Quantity * orderItem.UnitPrice * (1 - ((decimal)(request.Discount ?? 0) / 100));
	
		orderItem.OrderId = orderId;
		orderItem.MenuItemId = menuItemId;
		order.TotalAmount += orderItem.TotalPrice;

		await _orderItemRepository.AddAsync(orderItem, cancellationToken);
		await _orderRepository.UpdateAsync(order, cancellationToken);

		return Result.Success(orderItem.Adapt<OrderItemResponse>());

	}
}
