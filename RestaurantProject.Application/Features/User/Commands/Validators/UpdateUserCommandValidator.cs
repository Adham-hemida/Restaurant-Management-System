namespace RestaurantProject.Application.Features.User.Commands.Validators;
public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
	public UpdateUserCommandValidator()
	{
		RuleFor(x=>x.UpdateUserRequest)
			.NotNull()
			.WithMessage("UpdateUserRequest cannot be null")
			.SetValidator(new UpdateUserRequestValidator());
	}
}
