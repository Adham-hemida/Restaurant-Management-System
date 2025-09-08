using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Handlers;
public class UpdateStatusOfOrderCommandHandler(IOrderService orderService) : IRequestHandler<UpdateStatusOfOrderCommand, Result>
{
	private readonly IOrderService _orderService = orderService;

	public async Task<Result> Handle(UpdateStatusOfOrderCommand request, CancellationToken cancellationToken)
	{
		return await _orderService.UpdateStatusAsync(request.OrderId, request.StatusRequest, cancellationToken);
	}
}
