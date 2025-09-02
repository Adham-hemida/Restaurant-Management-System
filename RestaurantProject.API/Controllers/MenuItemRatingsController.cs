using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Features.MenuItemRating.Commands.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/MenuItem/{menuItemId}/[controller]")]
[ApiController]
[Authorize]
public class MenuItemRatingsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;
	[HttpPost("")]
	public async Task<IActionResult> Create([FromRoute] int orderId, [FromRoute] int menuItemId, [FromBody] MenuItemRatingRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddMenuItemRatingCommand(orderId, menuItemId, request), cancellationToken);
		return result.IsSuccess ? Ok(result.Value): result.ToProblem();
	}
}
