namespace RestaurantProject.Application.Features.User.Commands.Models;
public record ToggleUserStatusCommand (string UserId) : IRequest<Result>;