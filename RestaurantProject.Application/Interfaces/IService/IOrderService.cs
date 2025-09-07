namespace RestaurantProject.Application.Interfaces.IService;
public interface IOrderService
{
	Task<Result<OrderResponse>> GetAsync(int orderId, CancellationToken cancellationToken);
}
