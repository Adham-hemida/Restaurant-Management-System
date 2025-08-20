using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Authentication;
using RestaurantProject.Application.Interfaces.IAuthentication;


namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthsController(IAuthService authService) : ControllerBase
{
	private readonly IAuthService _authService = authService;

	[HttpPost("")]
	public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken = default)
	{
		var authResult = await _authService.GetTokenAsync(request, cancellationToken);
		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();

	}

	[HttpPost("Refresh")]
	public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
	{
		var authResult = await _authService.GetRefreshTokenAsync(request, cancellationToken);

		return authResult.IsSuccess ? Ok(authResult.Value) : authResult.ToProblem();

	}
}
