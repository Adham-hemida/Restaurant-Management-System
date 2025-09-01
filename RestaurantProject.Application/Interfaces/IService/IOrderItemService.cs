namespace RestaurantProject.Application.Interfaces.IService;
public interface IOrderItemService
{
	Task<Result<OrderItemResponse>> AddAsync(int orderId, int menuItemId, AddOrderItemRequest request, CancellationToken cancellationToken);

}
