namespace RestaurantProject.Application.Features.User.Commands.Validators;
public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
{
	public ChangePasswordCommandValidator()
	{
		RuleFor(x=>x.ChangePasswordRequest)
			.NotNull()
			.WithMessage("ChangePasswordRequest cannot be null")
			.SetValidator(new ChangePasswordRequestValidator());
	}
}
