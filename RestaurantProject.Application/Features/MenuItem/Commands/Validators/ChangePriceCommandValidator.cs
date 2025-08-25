using RestaurantProject.Application.Features.MenuItem.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Validators;
public class ChangePriceCommandValidator : AbstractValidator<ChangePriceCommand>
{
	public ChangePriceCommandValidator()
	{
		RuleFor(x=>x.ChangePriceRequest)
			.NotNull()
			.WithMessage("ChangePriceRequest cannot be null")
			.SetValidator(new ChangePriceRequestValidator());
	}
}
