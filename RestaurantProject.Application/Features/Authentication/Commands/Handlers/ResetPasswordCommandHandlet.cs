
namespace RestaurantProject.Application.Features.Authentication.Commands.Handlers;
public class ResetPasswordCommandHandlet(IAuthService authService) : IRequestHandler<ResetPasswordCommand, Result>
{
	private readonly IAuthService _authService = authService;

	public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
	{
		return await _authService.ResetPasswordAsync(request.ResetPasswordRequest);
	}
}
