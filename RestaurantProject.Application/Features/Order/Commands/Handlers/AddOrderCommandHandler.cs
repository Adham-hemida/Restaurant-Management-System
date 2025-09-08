using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Handlers;
public class AddOrderCommandHandler( IOrderService orderService) : IRequestHandler<AddOrderCommand, Result<OrderResponse>>
{
	private readonly IOrderService _orderService = orderService;

	public async Task<Result<OrderResponse>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
	{
		return await _orderService.AddAsync(request.OrderRequest, cancellationToken);
	}
}
