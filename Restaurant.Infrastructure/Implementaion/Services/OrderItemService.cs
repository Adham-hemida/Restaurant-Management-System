using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

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

		if (!orderIsExist)
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
