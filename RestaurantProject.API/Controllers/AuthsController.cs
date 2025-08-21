using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Authentication;
using RestaurantProject.Application.Features.Authentication.Commands.Models;
using RestaurantProject.Application.Interfaces.IAuthentication;


namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthsController(IAuthService authService,IMediator mediator) : ControllerBase
{
	private readonly IAuthService _authService = authService;
	private readonly IMediator _mediator = mediator;

	[HttpPost("")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
	{
		var authResult = await _mediator.Send(new LoginUserCommand(request));
		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();

	}

	[HttpPost("Refresh")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
	{
		var authResult = await _mediator.Send(new GenerateRefreshTokenCommand(request));

		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();

	}

	[HttpPost("revoke-refresh-token")]
	public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
	{
		var result = await _authService.RevokeRefreshTokenAsync(request, cancellationToken);
		return result.IsSuccess ? Ok() : result.ToProblem();

	}
}
