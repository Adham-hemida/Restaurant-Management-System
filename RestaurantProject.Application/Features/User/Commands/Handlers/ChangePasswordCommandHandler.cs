
namespace RestaurantProject.Application.Features.User.Commands.Handlers;
public class ChangePasswordCommandHandler(IUserService userService) : IRequestHandler<ChangePasswordCommand, Result>
{
	private readonly IUserService _userService = userService;

	public async Task<Result> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
	{
		return await _userService.ChangePasswordAsync(request.UserId, request.ChangePasswordRequest);
	}
}
