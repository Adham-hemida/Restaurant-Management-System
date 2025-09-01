using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.MenuItem.Commands.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;
using RestaurantProject.Application.Features.OrderItem.Queries.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/MenuItem/{menuItemId}/[controller]")]
[ApiController]
[Authorize]
public class OrderItemsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{orderItemId}")]
	public async Task<IActionResult> GetById([FromRoute] int orderId, [FromRoute] int menuItemId,[FromRoute] int orderItemId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetOrderItemQuery(orderId, menuItemId, orderItemId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	public async Task<IActionResult> Create([FromRoute] int orderId,[FromRoute] int menuItemId, [FromBody] AddOrderItemRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddOrderItemCommand(orderId, menuItemId, request), cancellationToken);

		return result.IsSuccess ? Ok( result.Value)	: result.ToProblem();
	}
}
