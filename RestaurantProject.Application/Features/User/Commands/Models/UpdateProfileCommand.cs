namespace RestaurantProject.Application.Features.User.Commands.Models;
public record UpdateProfileCommand(string UserId,UpdateProfileRequest UpdateProfileRequest) : IRequest<Result>;
