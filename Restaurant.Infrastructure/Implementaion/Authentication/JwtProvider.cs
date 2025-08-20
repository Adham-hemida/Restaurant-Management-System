using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantProject.Application.Interfaces.IAuthentication;
using RestaurantProject.Application.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantProject.Infrastructure.Implementaion.Authentication;
public class JwtProvider(IOptions<JwtOptions> options ): IJwtProvider
{
	private readonly JwtOptions _options = options.Value;

	public (string token, int expiresIn) GenerateJwtToken(ApplicationUser user)
	{
		Claim[] claims = [
			new(JwtRegisteredClaimNames.Sub,user.Id),
			new(JwtRegisteredClaimNames.Email,user.Email!),
			new(JwtRegisteredClaimNames.GivenName,user.FirstName),
			new(JwtRegisteredClaimNames.FamilyName,user.LastName),
			new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
			];

		var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));
		var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

		var token = new JwtSecurityToken(
					issuer: _options.Issuer,
					audience: _options.Audience,
					claims: claims,
					expires: DateTime.UtcNow.AddMinutes(_options.ExpiresInMinutes),
					signingCredentials: signingCredentials
					);
		return (new JwtSecurityTokenHandler().WriteToken(token), _options.ExpiresInMinutes * 60);
	}

	public string? ValidateToken(string token)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Key));

		try
		{
			tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuer = false,
				ValidateAudience = false,
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = symmetricSecurityKey,
				ClockSkew = TimeSpan.Zero
			}, out SecurityToken validatedToken);
			var jwtToken = (JwtSecurityToken)validatedToken;
			return jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
		}
		catch
		{
			return null;
		}
	}
}

