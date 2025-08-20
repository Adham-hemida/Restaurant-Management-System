namespace RestaurantProject.Application.Contracts.Authentication;

public record RefreshTokenRequest(
	string token,
	string refreshToken
	);