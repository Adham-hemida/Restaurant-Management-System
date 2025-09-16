namespace RestaurantProject.Application.Features.User.Commands.Validators;
public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
{
	public UpdateProfileCommandValidator()
	{
		RuleFor(x=>x.UpdateProfileRequest)
			.NotNull()
			.WithMessage("UpdateProfileRequest cannot be null")
			.SetValidator(new UpdateProfileRequestValidator());
	}
}
