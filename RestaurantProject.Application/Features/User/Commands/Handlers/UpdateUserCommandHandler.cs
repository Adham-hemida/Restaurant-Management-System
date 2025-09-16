
namespace RestaurantProject.Application.Features.User.Commands.Handlers;
public class UpdateUserCommandHandler(IUserService userService) : IRequestHandler<UpdateUserCommand, Result>
{
	private readonly IUserService _userService = userService;

	public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		return await _userService.UpdateAsync(request.UserId, request.UpdateUserRequest, cancellationToken);
	}
}
