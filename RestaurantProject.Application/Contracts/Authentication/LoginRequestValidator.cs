using FluentValidation;

namespace RestaurantProject.Application.Contracts.Authentication;
public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
	public LoginRequestValidator()
	{
		RuleFor(x => x.Email)
			.NotEmpty()
			.WithMessage("Email is required.")
			.EmailAddress()
			.WithMessage("Invalid email format.");

		RuleFor(x => x.Password)
			.NotEmpty();
	}
}
