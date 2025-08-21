namespace RestaurantProject.Application.Features.Authentication.Commands.Handlers;

public class GenerateRefreshTokenCommandHandler(IAuthService authService) : IRequestHandler<GenerateRefreshTokenCommand, Result<AuthResponse>>
{
	private readonly IAuthService _authService = authService;

	public async Task<Result<AuthResponse>> Handle(GenerateRefreshTokenCommand request, CancellationToken cancellationToken)
	{
		return await _authService.GetRefreshTokenAsync(request.RefreshTokenRequest, cancellationToken);
	}
}