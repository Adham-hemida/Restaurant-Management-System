namespace RestaurantProject.Application.Contracts.Order;
public class OrderRequestValidator : AbstractValidator<OrderRequest>
{
	public OrderRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.WithMessage("Name is required.")
			.MaximumLength(20)
			.WithMessage("Maximum Length 20 characters.");

		RuleFor(x => x.TableId)
			.NotEmpty()
			.WithMessage("TableId is required.")
		    .GreaterThan(0)
			.WithMessage("Number should greater than 0");

		RuleFor(x => x.OrderItems)
			.NotNull();

		RuleForEach(x => x.OrderItems)
			.SetInheritanceValidator(v =>	v.Add(new OrderItemRequestValidator()));
	}
}
