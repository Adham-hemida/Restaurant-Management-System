using RestaurantProject.Application.Features.OrderItem.Queries.Models;

namespace RestaurantProject.Application.Features.OrderItem.Queries.Handlers;
public class GetOrderItemQueryHandler(IOrderItemService orderItemService) : IRequestHandler<GetOrderItemQuery, Result<OrderItemResponse>>
{
	private readonly IOrderItemService _orderItemService = orderItemService;

	public async Task<Result<OrderItemResponse>> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
	{
		return await _orderItemService.GetAsync(request.OrderId, request.MenuItemId, request.OrderItemId, cancellationToken);
	}
}
