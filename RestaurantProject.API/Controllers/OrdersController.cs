using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.Order;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.Order.Commands.Models;
using RestaurantProject.Application.Features.Order.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;
using RestaurantProject.Application.Features.OrderItem.Queries.Models;
using RestaurantProject.Application.Features.Table.Commands.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	[HasPermission(Permissions.GetOrders)]
	public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetOrderQuery(id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("")]
	[HasPermission(Permissions.GetOrders)]
	public async Task<IActionResult> GetAll( [FromQuery] RequestFilters filters, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetAllOrdersQuery( filters), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("table/{tableId}")]
	[HasPermission(Permissions.GetOrders)]
	public async Task<IActionResult> GetByTable([FromRoute] int tableId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetByTableCommand(tableId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	[EnableRateLimiting(RateLimiters.FixedWindow)]
	[HasPermission(Permissions.AddOrders)]
	public async Task<IActionResult> Create( [FromBody] OrderRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddOrderCommand(request), cancellationToken);

		return result.IsSuccess
			? CreatedAtAction(nameof(GetById), new {  result.Value.Id }, result.Value)
			: result.ToProblem();
	}

	[HttpPut("{id}/toggle-delivered")]
	[HasPermission(Permissions.ToggleDeliveredOrders)]
	public async Task<IActionResult> ToggleDelivered([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ToggleDeliveredCommand(id), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpPut("{id}/update-satus")]
	[HasPermission(Permissions.UpdateOrders)]
	public async Task<IActionResult> UpdateSatus([FromRoute] int id, [FromBody] UpdateOrderStatusRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdateStatusOfOrderCommand(id, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpPut("{id}/toggle-active")]
	[HasPermission(Permissions.UpdateOrders)]
	public async Task<IActionResult> ToggleActive([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ToggleIsActiveCommand(id), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

	[HttpPut("{id}/move-to-table/{newTableId}")]
	[HasPermission(Permissions.MoveOrderToTable)]
	public async Task<IActionResult> MoveOrderToTable([FromRoute] int id,[FromRoute]int newTableId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new MoveOrderToTableCommand(id, newTableId), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}


}
