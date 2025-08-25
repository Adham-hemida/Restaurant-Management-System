using RestaurantProject.Application.Features.MenuItem.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItem.Commands.Validators;
public class AddMenuItemCommandValidator : AbstractValidator<AddMenuItemCommand>
{
	public AddMenuItemCommandValidator()
	{
		RuleFor(x => x.MenuItemRequest)
			.NotNull()
			.WithMessage("MenuItemRequest cannot be null")
			.SetValidator(new MenuItemRequestValidator());
	}
}
