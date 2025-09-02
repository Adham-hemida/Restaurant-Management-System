using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Features.MenuItemRating.Commands.Models;

namespace RestaurantProject.Application.Features.MenuItemRating.Commands.Validators;
public class AddMenuItemRatingCommandValidator : AbstractValidator<AddMenuItemRatingCommand>
{
	public AddMenuItemRatingCommandValidator()
	{
		RuleFor(x=>x.MenuItemRatingRequest)
			.NotNull()
			.WithMessage("MenuItemRatingRequest is required.")
			.SetValidator(new MenuItemRatingRequestValidator());
	}
}
