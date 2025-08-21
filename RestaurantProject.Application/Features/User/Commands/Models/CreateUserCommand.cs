namespace RestaurantProject.Application.Features.User.Commands.Models;

public record CreateUserCommand(CreateUserRequest CreateUserRequest) : IRequest<Result<UserResponse>>;

