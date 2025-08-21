namespace RestaurantProject.Application.Features.Authentication.Commands.Handlers;

public class LoginUserCommandHandler(IAuthService authService) : IRequestHandler<LoginUserCommand, Result<AuthResponse>>
{
	private readonly IAuthService _authService = authService;

	public async Task<Result<AuthResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{
          return await _authService.GetTokenAsync(request.LoginRequest, cancellationToken);
	}
}

