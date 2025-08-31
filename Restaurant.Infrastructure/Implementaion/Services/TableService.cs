using Azure.Core;
using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Table;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Consts;

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

	public async Task<Result<IEnumerable<TableResponse>>> GetAllAsync(CancellationToken cancellationToken)
	{
		var tables=await _tableRepository.GetAsQueryable()
			.AsNoTracking()
			.ProjectToType<TableResponse>()
			.ToListAsync(cancellationToken);

		return Result.Success<IEnumerable<TableResponse>>(tables);

	}

	public async Task<Result<TableResponse>> AddAsync(AddTableRequest request,CancellationToken cancellationToken)
	{
		var tableIsExist=await _tableRepository.GetAsQueryable()
			.AnyAsync(t => t.TableNumber == request.TableNumber, cancellationToken);

		if (tableIsExist)
			return Result.Failure<TableResponse>(TableErrors.DuplicatedTable);

		var table = request.Adapt<Table>();
		await _tableRepository.AddAsync(table, cancellationToken);
		return Result.Success(table.Adapt<TableResponse>());
	}

	public async Task<Result> UpdateAsync(int id,UpdateTableRequest request, CancellationToken cancellationToken)
	{
		var table = await _tableRepository.GetByIdAsync(id, cancellationToken);
		
		if (table is null)
			return Result.Failure(TableErrors.TableNotFound);

		var tableIsExist = await _tableRepository.GetAsQueryable().AnyAsync(x=>x.TableNumber == request.TableNumber && x.Id != id, cancellationToken);

		if(tableIsExist)
			return Result.Failure(TableErrors.DuplicatedTable);

		var tablesStatus = TableStatus.GetAllTablesStatus();

		if(!tablesStatus.Contains(request.Status))
			return Result.Failure(TableErrors.InvalidTableStatus);

		table = request.Adapt(table);
		await _tableRepository.UpdateAsync(table, cancellationToken);
		return Result.Success();
	}

	public async Task<Result> UpdateStatusAsync(int id, string status, CancellationToken cancellationToken)
	{
		var table = await _tableRepository.GetByIdAsync(id, cancellationToken);
		if (table is null)
			return Result.Failure(TableErrors.TableNotFound);

		var tablesStatus = TableStatus.GetAllTablesStatus();

		if (!tablesStatus.Contains(status))
			return Result.Failure(TableErrors.InvalidTableStatus);

		table.Status = status;
		await _tableRepository.UpdateAsync(table, cancellationToken);
		return Result.Success();
	}

	public async Task<Result> ToggleAvailabilityAsync(int id, CancellationToken cancellationToken)
	{
		var table = await _tableRepository.GetByIdAsync(id, cancellationToken);
		if (table is null)
			return Result.Failure(TableErrors.TableNotFound);

		if (table.Status == TableStatus.Available)
			table.Status = TableStatus.Unavailable;

		else if (table.Status == TableStatus.Unavailable)
			table.Status = TableStatus.Available;
		else
			return Result.Failure(TableErrors.InvalidTableStatus);

		await _tableRepository.UpdateAsync(table, cancellationToken);
		return Result.Success();
	}
}
