namespace RestaurantProject.Application.Features.OrderItem.Commands.Handlers;
public class UpdateOrderItemCommandHandler(IOrderItemService orderItemService) : IRequestHandler<UpdateOrderItemCommand, Result>
{
	private readonly IOrderItemService _orderItemService = orderItemService;

	public async Task<Result> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
	{
		return await _orderItemService.UpdateAsync(request.OrderId, request.MenuItemId, request.OrderItemId, request.AddOrderItemRequest, cancellationToken);
	}
}
