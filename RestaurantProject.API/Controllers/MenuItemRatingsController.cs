using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Features.MenuCategory.Command.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.MenuItemRating.Commands.Models;
using RestaurantProject.Application.Features.MenuItemRating.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Queries.Models;
using RestaurantProject.Domain.Entites;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/MenuItem/{menuItemId}/[controller]")]
[ApiController]
public class MenuItemRatingsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{menuItemRatingId}")]
	[HasPermission(Permissions.GetMenuItemRatings)]
	public async Task<IActionResult> GetById([FromRoute] int orderId, [FromRoute] int menuItemId,[FromRoute] int menuItemRatingId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuItemRatingQuery(orderId, menuItemId, menuItemRatingId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("~/api/MenuItem/{menuItemId}/MenuItemRatings")]
	[HasPermission(Permissions.GetMenuItemRatings)]
	public async Task<IActionResult> GetAll([FromRoute] int menuItemId, [FromQuery] RequestFilters filters, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetAllMenuItemsRatingQuery(menuItemId,filters), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	[HasPermission(Permissions.AddMenuItemRatings)]
	public async Task<IActionResult> Create([FromRoute] int orderId, [FromRoute] int menuItemId, [FromBody] MenuItemRatingRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddMenuItemRatingCommand(orderId, menuItemId, request), cancellationToken);
		return result.IsSuccess ?CreatedAtAction(nameof(GetById),new { orderId , menuItemId , menuItemRatingId =result.Value.Id},result.Value): result.ToProblem();
	}

	[HttpPut("{menuItemRatingId}/toggleStatus")]
	[HasPermission(Permissions.UpdateMenuItemRatings)]
	public async Task<IActionResult> ToggleStatus([FromRoute] int orderId, [FromRoute] int menuItemId, [FromRoute] int menuItemRatingId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new MenuItemRatingToggleStatusCommand(orderId, menuItemId, menuItemRatingId), cancellationToken);

		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

}
