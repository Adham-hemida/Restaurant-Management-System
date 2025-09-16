namespace RestaurantProject.Application.Contracts.User;
public record ChangePasswordRequest(
	string CurrentPassword,
	string NewPassword
	);