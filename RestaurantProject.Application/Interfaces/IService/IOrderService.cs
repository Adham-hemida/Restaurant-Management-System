using RestaurantProject.Application.Contracts.Common;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IOrderService
{
	Task<Result<OrderResponse>> GetAsync(int orderId, CancellationToken cancellationToken);
	Task<Result<PaginatedList<OrderResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken);
}
