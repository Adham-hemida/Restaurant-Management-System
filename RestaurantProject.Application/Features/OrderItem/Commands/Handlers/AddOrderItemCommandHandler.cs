
namespace RestaurantProject.Application.Features.OrderItem.Commands.Handlers;
public class AddOrderItemCommandHandler(IOrderItemService orderItemService) : IRequestHandler<AddOrderItemCommand, Result<OrderItemResponse>>
{
	private readonly IOrderItemService _orderItemService = orderItemService;

	public async Task<Result<OrderItemResponse>> Handle(AddOrderItemCommand request, CancellationToken cancellationToken)
	{
		return await _orderItemService.AddAsync(request.OrderId, request.MenuItemId, request.AddOrderItemRequest, cancellationToken);
	}
}
