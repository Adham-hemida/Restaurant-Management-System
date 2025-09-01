namespace RestaurantProject.Application.Features.OrderItem.Commands.Handlers;
public class DeleteOrderItemCommandHandler(IOrderItemService orderItemService) : IRequestHandler<DeleteOrderItemCommand, Result>
{
	private readonly IOrderItemService _orderItemService = orderItemService;

	public async Task<Result> Handle(DeleteOrderItemCommand request, CancellationToken cancellationToken)
	{
		return await _orderItemService.DeleteAsync(request.OrderId, request.MenuItemId, request.OrderItemId, cancellationToken);
	}
}
