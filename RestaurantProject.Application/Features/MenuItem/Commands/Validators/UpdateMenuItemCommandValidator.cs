using RestaurantProject.Application.Features.MenuItem.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Validators;
public class UpdateMenuItemCommandValidator : AbstractValidator<UpdateMenuItemCommand>
{
	public UpdateMenuItemCommandValidator()
	{
		RuleFor(x => x.MenuItemRequest)
			.NotNull()
			.WithMessage("MenuItemRequest cannot be null")
			.SetValidator(new MenuItemRequestValidator());
	}
}
