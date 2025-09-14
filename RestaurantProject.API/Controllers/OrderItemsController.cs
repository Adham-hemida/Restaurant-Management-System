using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.MenuItem.Commands.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;
using RestaurantProject.Application.Features.OrderItem.Queries.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/MenuItem/{menuItemId}/[controller]")]
[ApiController]
public class OrderItemsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{orderItemId}")]
	[HasPermission(Permissions.GetOrderItems)]
	public async Task<IActionResult> GetById([FromRoute] int orderId, [FromRoute] int menuItemId,[FromRoute] int orderItemId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetOrderItemQuery(orderId, menuItemId, orderItemId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("~/api/Order/{orderId}/OrderItems")]
	[HasPermission(Permissions.GetOrderItems)]
	public async Task<IActionResult> GetAll([FromRoute] int orderId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetAllOrderItemsQuery(orderId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	[HasPermission(Permissions.AddOrderItems)]
	public async Task<IActionResult> Create([FromRoute] int orderId,[FromRoute] int menuItemId, [FromBody] AddOrderItemRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddOrderItemCommand(orderId, menuItemId, request), cancellationToken);

		return result.IsSuccess 
			? CreatedAtAction(nameof(GetById),new {orderId, menuItemId , orderItemId=result.Value.Id},result.Value)	
			: result.ToProblem();
	}

	[HttpPut("{orderItemId}")]
	[HasPermission(Permissions.UpdateOrderItems)]
	public async Task<IActionResult> Update([FromRoute] int orderId, [FromRoute] int menuItemId, [FromRoute] int orderItemId, [FromBody] AddOrderItemRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdateOrderItemCommand(orderId, menuItemId, orderItemId,request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpDelete("{orderItemId}")]
	[HasPermission(Permissions.DeleteOrderItems)]
	public async Task<IActionResult> Delete([FromRoute] int orderId, [FromRoute] int menuItemId, [FromRoute] int orderItemId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeleteOrderItemCommand(orderId, menuItemId, orderItemId), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

	[HttpDelete("~/api/Order/{orderId}/OrderItems")]
	[HasPermission(Permissions.DeleteOrderItems)]
	public async Task<IActionResult> DeleteRange([FromRoute] int orderId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new DeleteAllOrderItemsCommand(orderId), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

}
