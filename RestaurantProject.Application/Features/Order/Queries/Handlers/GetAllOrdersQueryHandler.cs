namespace RestaurantProject.Application.Features.Order.Queries.Handlers;
public class GetAllOrdersQueryHandler (IOrderService orderService) : IRequestHandler<GetAllOrdersQuery, Result<PaginatedList<OrderResponse>>>
{
	private readonly IOrderService _orderService = orderService;
	public async Task<Result<PaginatedList<OrderResponse>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
	{
		return await _orderService.GetAllAsync(request.RequestFilters, cancellationToken);
	}
}
