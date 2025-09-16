using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.User;
using RestaurantProject.Application.Features.User.Commands.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost("")]
	[HasPermission(Permissions.AddUsers)]
	public async Task<IActionResult>Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new CreateUserCommand(request), cancellationToken);
		return result.IsSuccess ? Ok(result.Value): result.ToProblem();
	}
}
