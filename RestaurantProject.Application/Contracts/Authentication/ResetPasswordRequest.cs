namespace RestaurantProject.Application.Contracts.Authentication;
public record ResetPasswordRequest(
	string Email,
	string Code,
	string NewPassword
);