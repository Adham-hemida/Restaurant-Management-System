namespace RestaurantProject.Application.Features.User.Commands.Models;
public record UnLockUserCommand(string UserId) : IRequest<Result>;
