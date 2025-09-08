namespace RestaurantProject.Application.Features.Order.Queries.Handlers;
public class GetByTableCommandHandler (IOrderService orderService) : IRequestHandler<GetByTableCommand, Result<IEnumerable<OrderResponse>>>
{
	private readonly IOrderService _orderService = orderService;
	public Task<Result<IEnumerable<OrderResponse>>> Handle(GetByTableCommand request, CancellationToken cancellationToken)
	{
		return _orderService.GetByTableAsync(request.TableId, cancellationToken);
	}
}
