using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Authentication;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IAuthentication;
using System.Security.Cryptography;

namespace RestaurantProject.Infrastructure.Implementaion.Authentication;
public class AuthService(UserManager<ApplicationUser> userManager,
	SignInManager<ApplicationUser> signInManager,
	IJwtProvider jwtProvider) : IAuthService
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
	private readonly IJwtProvider _jwtProvider = jwtProvider;
	private readonly int _refreshTokenExpirationDays = 14;

	public async Task<Result<AuthResponse>> GetTokenAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default)
	{
		if (await _userManager.FindByEmailAsync(loginRequest.Email) is not { } user)
			return Result.Failure<AuthResponse>(UserErrors.InvalidCredentials);

		if (user.IsDisabled)
			return Result.Failure<AuthResponse>(UserErrors.DisabledUser);

		var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, isPersistent: false, lockoutOnFailure: true);
		if (result.Succeeded)
		{
			var (token, expiresIn) = _jwtProvider.GenerateJwtToken(user);

			var refreshToken = GenerateRefreshToken();
			var refreshTokenExpiration = DateTime.UtcNow.AddDays(_refreshTokenExpirationDays);

			user.RefreshTokens.Add(new RefreshToken
			{
				Token = refreshToken,
				ExpiresOn = refreshTokenExpiration
			});

			await _userManager.UpdateAsync(user);
			var response = new AuthResponse(user.Id, user.Email, user.FirstName, user.LastName, token, expiresIn, refreshToken, refreshTokenExpiration);
			return Result.Success(response);
		}
		var error = result.IsNotAllowed
			? UserErrors.EmailNotConfirmed
			: result.IsLockedOut
			? UserErrors.LockedUser
			: UserErrors.InvalidCredentials;

		return Result.Failure<AuthResponse>(error);
	}

	private static string GenerateRefreshToken()
	{
		return Convert.ToBase64String(RandomNumberGenerator.GetBytes(32));
	}

}
