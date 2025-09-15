using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Role;
using RestaurantProject.Application.Features.Role.Commands.Models;
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

	[HttpGet("{id}")]
	[HasPermission(Permissions.GetRoles)]
	public async Task<IActionResult> Get([FromRoute] string id)
	{
		var result = await _mediator.Send(new GetRoleQuery(id));
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	[HasPermission(Permissions.AddRoles)]
	public async Task<IActionResult> Add([FromBody] RoleRequest request)
	{
		var result = await _mediator.Send(new AddRoleCommands(request));
		return result.IsSuccess ? CreatedAtAction(nameof(Get), new { result.Value.Id }, result.Value) : result.ToProblem();
	}

	[HttpPut("{id}")]
	[HasPermission(Permissions.UpdateRoles)]
	public async Task<IActionResult> Update([FromRoute] string id, [FromBody] RoleRequest request)
	{
		var result = await _mediator.Send(new UpdateRoleCommand(id, request));
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

	[HttpPut("{id}/toggle-status")]
	[HasPermission(Permissions.UpdateRoles)]
	public async Task<IActionResult> ToggleStatus([FromRoute] string id)
	{
		var result = await _mediator.Send(new RoleToggleSatausCommand(id));
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
}
