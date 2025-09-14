using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Application.Interfaces.IAuthentication;
public interface IJwtProvider
{
	(string token, int expiresIn) GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles, IEnumerable<string> permissions);
	string? ValidateToken(string token);
}
