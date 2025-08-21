namespace RestaurantProject.Application.Features.Authentication.Commands.Handlers;

public class RevokeRefreshTokenCommandHandler(IAuthService authService) : IRequestHandler<RevokeRefreshTokenCommand, Result>
{
	private readonly IAuthService _authService = authService;

	public async Task<Result> Handle(RevokeRefreshTokenCommand request, CancellationToken cancellationToken)
	{
		return await _authService.RevokeRefreshTokenAsync(request.RefreshTokenRequest, cancellationToken);
	}

}

