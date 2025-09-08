using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Handlers;
public class MoveOrderToTableCommandHandler (IOrderService orderService) : IRequestHandler<MoveOrderToTableCommand, Result>
{
	private readonly IOrderService _orderService = orderService;
	public Task<Result> Handle(MoveOrderToTableCommand request, CancellationToken cancellationToken)
	{
		return _orderService.MoveOrderToTableAsync(request.OrderId, request.NewTableId, cancellationToken);
	}
}
