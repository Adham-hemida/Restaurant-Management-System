using RestaurantProject.Application.Features.OrderItem.Queries.Models;

namespace RestaurantProject.Application.Features.OrderItem.Queries.Handlers;
public class GetAllOrderItemsQueryHandlers(IOrderItemService orderItemService) : IRequestHandler<GetAllOrderItemsQuery, Result<IEnumerable<OrderItemResponse>>>
{
	private readonly IOrderItemService _orderItemService = orderItemService;

	public async Task<Result<IEnumerable<OrderItemResponse>>> Handle(GetAllOrderItemsQuery request, CancellationToken cancellationToken)
	{
		return await _orderItemService.GetAllAsync(request.OrderId, cancellationToken);
	}
}
