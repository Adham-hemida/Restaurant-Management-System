using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;

namespace RestaurantProject.Application.ErrorHandler;
public record UserErrors
{
	public static readonly Error InvalidCredentials =
		new("invalid.credentials", "Invalid Email/Password", StatusCodes.Status401Unauthorized);

	public static readonly Error DisabledUser =
		new("User.DisabledUser", "Disabled user, please contact your administrator", StatusCodes.Status401Unauthorized);

	public static readonly Error LockedUser =
		new("User.LockedUser", "Locked user, please contact your administrator", StatusCodes.Status401Unauthorized);

	public static readonly Error EmailNotConfirmed =
		new("User.EmailNotConfirmed", "Email is not confirmed", StatusCodes.Status401Unauthorized);

	public static readonly Error InvalidJwtTokens =
	new("User.InvalidJwtToken", "Invalid Jwt token", StatusCodes.Status401Unauthorized);

	public static readonly Error InvalidRefreshToken =
	   new("User.InvalidRefreshToken", "Invalid refresh token", StatusCodes.Status401Unauthorized);

	public static readonly Error UserNotFound =
	  new("User.UserNotFound", "User is not found", StatusCodes.Status404NotFound);

	public static readonly Error DuplicatedEmail =
	new("User.DuplicatedEmail", "Another user with the same email is already exists", StatusCodes.Status409Conflict);
}
