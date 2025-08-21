namespace RestaurantProject.Application.Features.User.Commands.Handlers;

public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand, Result<UserResponse>>
{
	private readonly IUserService _userService = userService;

	public async Task<Result<UserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
	{
		return await _userService.CreateAsync(request.CreateUserRequest);
		
	}
}

