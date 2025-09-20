using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Authentication;
using RestaurantProject.Application.Features.Authentication.Commands.Models;
using RestaurantProject.Application.Interfaces.IAuthentication;
using RestaurantProject.Infrastructure.Implementaion.Authentication;


namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost("")]
	[EnableRateLimiting(RateLimiters.IpLimiter)]
	public async Task<IActionResult> Login([FromBody] Application.Contracts.Authentication.LoginRequest request, CancellationToken cancellationToken = default)
	{
		var authResult = await _mediator.Send(new LoginUserCommand(request),cancellationToken);
		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();

	}

	[HttpPost("Refresh")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
	{
		var authResult = await _mediator.Send(new GenerateRefreshTokenCommand(request),cancellationToken);

		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();

	}

	[HttpPost("revoke-refresh-token")]
	public async Task<IActionResult> RevokeRefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
	{
		var result = await _mediator.Send(new RevokeRefreshTokenCommand(request),cancellationToken);
		return result.IsSuccess ? Ok() : result.ToProblem();
	}

	[HttpPost("forget-password")]
	public async Task<IActionResult> ForgetPassword([FromBody] string email)
	{
		var result = await _mediator.Send(new SendResetPasswordCodeCommand(email));

		return result.IsSuccess ? Ok() : result.ToProblem();
	}

	[HttpPost("reset-password")]
	public async Task<IActionResult> ResetPassword([FromBody] Application.Contracts.Authentication.ResetPasswordRequest request)
	{
		var result = await _mediator.Send(new ResetPasswordCommand(request));

		return result.IsSuccess ? Ok() : result.ToProblem();
	}
}
