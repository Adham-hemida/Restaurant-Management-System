using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Features.Role.Queries.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RolesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("")]
	[HasPermission(Permissions.GetRoles)]
	public async Task<IActionResult> GetAll([FromQuery] bool includeDisabled, CancellationToken cancellationToken)
	{
		var roles = await _mediator.Send(new GetAllRolesQuery(includeDisabled),cancellationToken);
		return Ok(roles);
	}
}
