namespace RestaurantProject.Application.Features.Authentication.Commands.Models;
public record SendResetPasswordCodeCommand(string Email) : IRequest<Result>;
