namespace RestaurantProject.Application.Features.User.Commands.Models;
public record UpdateUserCommand(string UserId, UpdateUserRequest UpdateUserRequest) : IRequest<Result>;
