namespace RestaurantProject.Application.Features.User.Commands.Models;
public record ChangePasswordCommand(string UserId, ChangePasswordRequest ChangePasswordRequest) : IRequest<Result>;