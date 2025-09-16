using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Extensions;
using RestaurantProject.Application.Features.User.Queries.Models;

namespace RestaurantProject.API.Controllers;
[Route("me")]
[ApiController]
[Authorize]
public class AccountsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("")]
	public async Task<IActionResult> Info()
	{
		var result = await _mediator.Send(new GetProfileInfoQuery(User.GetUserId()!));
		return Ok(result.Value);
	}
}
