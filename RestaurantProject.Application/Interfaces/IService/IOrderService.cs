using RestaurantProject.Application.Contracts.Common;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IOrderService
{
	Task<Result<OrderResponse>> GetAsync(int orderId, CancellationToken cancellationToken);
	Task<Result<PaginatedList<OrderResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken);
	Task<Result<OrderResponse>> AddAsync(OrderRequest request, CancellationToken cancellationToken);
	Task<Result> ToggleDeliveredAsync(int orderId, CancellationToken cancellationToken);
	Task<Result> UpdateStatusAsync(int id, UpdateOrderStatusRequest request, CancellationToken cancellationToken);
	Task<Result> ToggleIsActiveAsync(int orderId, CancellationToken cancellationToken);
	Task<Result> MoveOrderToTableAsync(int orderId, int newTableId, CancellationToken cancellationToken);
	Task<Result<IEnumerable<OrderResponse>>> GetByTableAsync(int tableId, CancellationToken cancellationToken);
}
