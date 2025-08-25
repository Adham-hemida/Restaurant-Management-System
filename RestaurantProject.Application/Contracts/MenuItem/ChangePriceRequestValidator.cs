namespace RestaurantProject.Application.Contracts.MenuItem;
public class ChangePriceRequestValidator : AbstractValidator<ChangePriceRequest>
{
	public ChangePriceRequestValidator()
	{
		RuleFor(x => x.Price)
           .NotEmpty()
           .WithMessage("Price is required.")
           .GreaterThan(0)
           .WithMessage("Price should be greater than 0.");

	}
}
