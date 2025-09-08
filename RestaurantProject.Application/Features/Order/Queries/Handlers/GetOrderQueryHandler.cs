
namespace RestaurantProject.Application.Features.Order.Queries.Handlers;
public class GetOrderQueryHandler(IOrderService orderService) : IRequestHandler<GetOrderQuery, Result<OrderResponse>>
{
	private readonly IOrderService _orderService = orderService;

	public async Task<Result<OrderResponse>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
	{
		return await _orderService.GetAsync(request.OrderId, cancellationToken);
			
	}
}
