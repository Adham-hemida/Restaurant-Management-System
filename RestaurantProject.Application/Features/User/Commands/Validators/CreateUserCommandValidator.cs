using RestaurantProject.Application.Features.User.Commands.Models;

namespace RestaurantProject.Application.Features.User.Commands.Validators;
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
	public CreateUserCommandValidator()
	{
		RuleFor(x => x.CreateUserRequest)
			.NotNull()
			.WithMessage("CreateUserRequest cannot be null.")
			.SetValidator(new CreateUserRequestValidator());
	}
}
