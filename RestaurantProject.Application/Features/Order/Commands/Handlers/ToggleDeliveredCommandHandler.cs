using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Handlers;
public class ToggleDeliveredCommandHandler (IOrderService orderService) : IRequestHandler<ToggleDeliveredCommand, Result>
{
	private readonly IOrderService _orderService = orderService;
	public async Task<Result> Handle(ToggleDeliveredCommand request, CancellationToken cancellationToken)
	{
		return await _orderService.ToggleDeliveredAsync(request.OrderId, cancellationToken);
	}
}
