using RestaurantProject.Application.Features.Table.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Application.Features.Table.Commands.Handlers;
public class UpdateStatusOfTableCommandHandler(ITableService tableService) : IRequestHandler<UpdateStatusOfTableCommand, Result>
{
	private readonly ITableService _tableService = tableService;

	public async Task<Result> Handle(UpdateStatusOfTableCommand request, CancellationToken cancellationToken)
	{
		return await _tableService.UpdateStatusAsync(request.TableId, request.Status, cancellationToken);
	}
}
