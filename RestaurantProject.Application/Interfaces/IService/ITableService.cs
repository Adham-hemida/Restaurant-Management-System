using RestaurantProject.Application.Contracts.Common;
using System.Threading.Tasks;

namespace RestaurantProject.Application.Interfaces.IService;
public interface ITableService
{
	Task<Result<TableResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
	Task<Result<PaginatedList<TableResponse>>> GetAllAsync(RequestFilters filters, CancellationToken cancellationToken);
	Task<Result<TableResponse>> AddAsync(AddTableRequest request, CancellationToken cancellationToken);
	Task<Result> UpdateAsync(int id, UpdateTableRequest request, CancellationToken cancellationToken);
	Task<Result> UpdateStatusAsync(int id, string status, CancellationToken cancellationToken);
	Task<Result> ToggleAvailabilityAsync(int id, CancellationToken cancellationToken);

}
