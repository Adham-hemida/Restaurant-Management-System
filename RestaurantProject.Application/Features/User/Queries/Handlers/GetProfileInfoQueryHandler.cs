using RestaurantProject.Application.Features.User.Queries.Models;

namespace RestaurantProject.Application.Features.User.Queries.Handlers;
public class GetProfileInfoQueryHandler (IUserService userService) : IRequestHandler<GetProfileInfoQuery, Result<UserProfileResponse>>
{
	private readonly IUserService _userService = userService;

	public async Task<Result<UserProfileResponse>> Handle(GetProfileInfoQuery request, CancellationToken cancellationToken)
	{
		return await _userService.GetProfileInfoAsync(request.UserId);
	}
}
