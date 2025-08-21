using FluentValidation;
using RestaurantProject.Application.Contracts.Authentication;
using RestaurantProject.Application.Features.Authentication.Commands.Models;

namespace RestaurantProject.Application.Features.Authentication.Commands.Validators;
public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
	public LoginUserCommandValidator()
	{
		RuleFor(x => x.LoginRequest)
				.NotNull()
				.WithMessage("Login request cannot be null.")
				.SetValidator(new LoginRequestValidator());


	}
}
