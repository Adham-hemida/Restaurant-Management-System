namespace RestaurantProject.Application.Contracts.Order;
public class OrderItemRequestValidator : AbstractValidator<OrderItemRequest>
{
	public OrderItemRequestValidator()
	{
		RuleFor(x=>x.MenuItemId)
			.GreaterThan(0)
			.WithMessage("MenuItemId must be greater than 0.");

		RuleFor(x => x.Quantity)
            .NotEmpty()
            .WithMessage("Quantity is required")
            .GreaterThan(0)
            .WithMessage("Quantity must be greater than 0");

		RuleFor(x => x.Discount)
			.GreaterThanOrEqualTo(0)
			.WithMessage("Discount must be greater than or equal to 0")
			.LessThanOrEqualTo(100)
			.WithMessage("Discount must be between 0 and 100");

		RuleFor(x => x.Notes)
			.MaximumLength(300)
			.WithMessage("Notes must be less than or equal to 300 characters");

	}
}
