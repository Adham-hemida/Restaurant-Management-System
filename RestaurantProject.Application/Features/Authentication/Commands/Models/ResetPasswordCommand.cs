namespace RestaurantProject.Application.Features.Authentication.Commands.Models;
public record ResetPasswordCommand (ResetPasswordRequest ResetPasswordRequest) : IRequest<Result>;
