using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.Table.Queries.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TablesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute]int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetTableQuery(id),cancellationToken);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("")]
	public async Task<IActionResult> GetAll( CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetAllTablesQuery(), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

}
