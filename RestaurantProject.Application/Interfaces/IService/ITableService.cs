namespace RestaurantProject.Application.Interfaces.IService;
public interface ITableService
{
	Task<Result<TableResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
}
