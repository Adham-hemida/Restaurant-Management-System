using RestaurantProject.Application.Features.User.Queries.Models;

namespace RestaurantProject.Application.Features.User.Queries.Handlers;
public class GetUserCommandHandler(IUserService userService) : IRequestHandler<GetUserCommand, Result<UserResponse>>
{
	private readonly IUserService _userService = userService;

	public async Task<Result<UserResponse>> Handle(GetUserCommand request, CancellationToken cancellationToken)
	{
		return await _userService.GetAsync(request.UserId);
	}
}
