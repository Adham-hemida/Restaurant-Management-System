using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Table;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class TableService(ITableRepository tableRepository): ITableService
{
	private readonly ITableRepository _tableRepository = tableRepository;

	public async Task<Result<TableResponse>>GetAsync(int id, CancellationToken cancellationToken)
	{
		var table=await _tableRepository.GetAsQueryable()
			.Where(t => t.Id == id)
			.Select(t => new TableResponse(
				t.Id,
				t.TableNumber,
				t.SeatsCount,
				t.Status
				)).SingleOrDefaultAsync(cancellationToken);

		if (table is null)
			return Result.Failure<TableResponse>(TableErrors.TableNotFound);

		return Result.Success(table);
	}
}
