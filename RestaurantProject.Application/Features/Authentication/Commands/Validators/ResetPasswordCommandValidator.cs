namespace RestaurantProject.Application.Features.Authentication.Commands.Validators;
public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
{
	public ResetPasswordCommandValidator()
	{
		RuleFor(x=>x.ResetPasswordRequest)
			.NotNull()
			.WithMessage("Reset password request is required.")
			.SetValidator(new ResetPasswordRequestValidator());

	}
}
