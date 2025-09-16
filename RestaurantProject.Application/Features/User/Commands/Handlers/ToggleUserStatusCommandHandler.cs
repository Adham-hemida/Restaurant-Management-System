
namespace RestaurantProject.Application.Features.User.Commands.Handlers;
public class ToggleUserStatusCommandHandler(IUserService userService) : IRequestHandler<ToggleUserStatusCommand, Result>
{
	private readonly IUserService _userService = userService;

	public async Task<Result> Handle(ToggleUserStatusCommand request, CancellationToken cancellationToken)
	{
		return await _userService.ToggleStatusAsync(request.UserId);
	}
}
