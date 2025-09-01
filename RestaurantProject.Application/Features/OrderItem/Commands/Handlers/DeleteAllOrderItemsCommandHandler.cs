
namespace RestaurantProject.Application.Features.OrderItem.Commands.Handlers;
public class DeleteAllOrderItemsCommandHandler(IOrderItemService orderItemService) : IRequestHandler<DeleteAllOrderItemsCommand, Result>
{
	private readonly IOrderItemService _orderItemService = orderItemService;

	public async Task<Result> Handle(DeleteAllOrderItemsCommand request, CancellationToken cancellationToken)
	{
		return await _orderItemService.DeleteAllAsync(request.OrderId, cancellationToken);
	}
}
