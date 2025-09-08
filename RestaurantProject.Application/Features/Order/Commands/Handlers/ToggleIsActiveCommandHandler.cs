using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Handlers;
public class ToggleIsActiveCommandHandler( IOrderService orderService) : IRequestHandler<ToggleIsActiveCommand, Result>
{
	private readonly IOrderService _orderService = orderService;

	public Task<Result> Handle(ToggleIsActiveCommand request, CancellationToken cancellationToken)
	{
		return _orderService.ToggleIsActiveAsync(request.OrderId, cancellationToken);
	}
}
