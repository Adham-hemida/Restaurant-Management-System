
namespace RestaurantProject.Application.Features.User.Commands.Handlers;
public class UnLockUserCommandHandler(IUserService userService) : IRequestHandler<UnLockUserCommand, Result>
{
	private readonly IUserService _userService = userService;

	public Task<Result> Handle(UnLockUserCommand request, CancellationToken cancellationToken)
	{
		return _userService.UnlockAsync(request.UserId);
	}
}
