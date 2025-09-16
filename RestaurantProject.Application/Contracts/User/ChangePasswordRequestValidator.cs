using RestaurantProject.Application.Abstractions.Consts;

namespace RestaurantProject.Application.Contracts.User;
public class ChangePasswordRequestValidator : AbstractValidator<ChangePasswordRequest>
{
	public ChangePasswordRequestValidator()
	{
		RuleFor(x => x.CurrentPassword)
			.NotEmpty();

		RuleFor(x => x.NewPassword)
			.NotEmpty()
			.Matches(RegexPatterns.Password)
			.WithMessage("Password should be at least 8 digits and should contains Lowercase, NonAlphanumeric and Uppercase")
			.NotEqual(x => x.CurrentPassword)
			.WithMessage("New password should not be same as current password");
	}
}