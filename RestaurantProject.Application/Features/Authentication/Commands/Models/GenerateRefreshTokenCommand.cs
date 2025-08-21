namespace RestaurantProject.Application.Features.Authentication.Commands.Models;

public record GenerateRefreshTokenCommand(RefreshTokenRequest RefreshTokenRequest) : IRequest<Result<AuthResponse>>;
