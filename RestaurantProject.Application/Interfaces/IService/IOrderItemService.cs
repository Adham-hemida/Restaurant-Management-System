namespace RestaurantProject.Application.Interfaces.IService;
public interface IOrderItemService
{
	Task<Result<OrderItemResponse>> AddAsync(int orderId, int menuItemId, AddOrderItemRequest request, CancellationToken cancellationToken);
	Task<Result<OrderItemResponse>> GetAsync(int orderId, int menuItemId, int orderItemId, CancellationToken cancellationToken);

}
