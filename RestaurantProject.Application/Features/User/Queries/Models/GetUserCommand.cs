namespace RestaurantProject.Application.Features.User.Queries.Models;
public record GetUserCommand(string UserId) : IRequest<Result<UserResponse>>;