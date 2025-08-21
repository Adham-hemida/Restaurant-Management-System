namespace RestaurantProject.Application.Features.Authentication.Commands.Models;

public record RevokeRefreshTokenCommand(RefreshTokenRequest RefreshTokenRequest) : IRequest<Result>;

