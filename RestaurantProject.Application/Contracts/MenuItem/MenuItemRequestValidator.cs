namespace RestaurantProject.Application.Contracts.MenuItem;
public class MenuItemRequestValidator : AbstractValidator<MenuItemRequest>
{
	public MenuItemRequestValidator()
	{
		RuleFor(x => x.Name)
		.NotEmpty()
		.WithMessage("Name is required.")
		.MaximumLength(50)
		.WithMessage("Name maximum should be  50 characters.");

		RuleFor(x => x.Description)
			.NotEmpty()
			.WithMessage("Description is required.")
			.MaximumLength(500)
			.WithMessage("Description maximum should be 500 characters.");

		RuleFor(x => x.Price)
			.NotEmpty()
			.WithMessage("Price is required.")
			.GreaterThan(0)
			.WithMessage("Price should be greater than 0.");
	}
}
