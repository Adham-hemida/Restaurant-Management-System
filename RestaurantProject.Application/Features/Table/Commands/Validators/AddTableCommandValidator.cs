using RestaurantProject.Application.Features.Table.Commands.Models;

namespace RestaurantProject.Application.Features.Table.Commands.Validators;
public class AddTableCommandValidator : AbstractValidator<AddTableCommand>
{
	public AddTableCommandValidator()
	{
		RuleFor(x=>x.AddTableRequest)
			.NotNull()
			.WithMessage("AddTableRequest cannot be null.")
			.SetValidator(new AddTableRequestValidator());
	}
}
