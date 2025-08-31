using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.Table;
using RestaurantProject.Application.Features.MenuItem.Commands.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.Table.Commands.Models;
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


	[HttpPost("")]
	public async Task<IActionResult> Create( [FromBody] AddTableRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddTableCommand(request), cancellationToken);

		return result.IsSuccess
			? CreatedAtAction(nameof(GetById), new {  result.Value.Id }, result.Value)
			: result.ToProblem();
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTableRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdateTableCommand( id, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}


}
