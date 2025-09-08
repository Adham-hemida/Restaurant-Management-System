using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.Order;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.Order.Commands.Models;
using RestaurantProject.Application.Features.Order.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;
using RestaurantProject.Application.Features.OrderItem.Queries.Models;
using RestaurantProject.Application.Features.Table.Commands.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetOrderQuery(id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("")]
	public async Task<IActionResult> GetAll( [FromQuery] RequestFilters filters, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetAllOrdersQuery( filters), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	public async Task<IActionResult> Create( [FromBody] OrderRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddOrderCommand(request), cancellationToken);

		return result.IsSuccess
			? CreatedAtAction(nameof(GetById), new {  result.Value.Id }, result.Value)
			: result.ToProblem();
	}

	[HttpPut("{id}/toggle-delivered")]
	public async Task<IActionResult> ToggleDelivered([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ToggleDeliveredCommand(id), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpPut("{id}/toggle-satus")]
	public async Task<IActionResult> ToggleSatus([FromRoute] int id, [FromBody] UpdateOrderStatusRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdateStatusOfOrderCommand(id, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpPut("{id}/toggle-active")]
	public async Task<IActionResult> ToggleActive([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ToggleIsActiveCommand(id), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

	[HttpPut("{id}/move-to-table/{newTableId}")]
	public async Task<IActionResult> MoveOrderToTable([FromRoute] int id,[FromRoute]int newTableId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new MoveOrderToTableCommand(id, newTableId), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
}
