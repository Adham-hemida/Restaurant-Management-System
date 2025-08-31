namespace RestaurantProject.Application.Interfaces.IService;
public interface ITableService
{
	Task<Result<TableResponse>> GetAsync(int id, CancellationToken cancellationToken = default);
	Task<Result<IEnumerable<TableResponse>>> GetAllAsync(CancellationToken cancellationToken);

}
