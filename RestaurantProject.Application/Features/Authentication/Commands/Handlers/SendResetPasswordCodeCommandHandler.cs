namespace RestaurantProject.Application.Features.Authentication.Commands.Handlers;
public class SendResetPasswordCodeCommandHandler (IAuthService authService) : IRequestHandler<SendResetPasswordCodeCommand, Result>
{
	private readonly IAuthService _authService = authService;
	public async Task<Result> Handle(SendResetPasswordCodeCommand request, CancellationToken cancellationToken)
	{
		return await _authService.SendResetPasswordCodeAsync(request.Email);
	}
}
