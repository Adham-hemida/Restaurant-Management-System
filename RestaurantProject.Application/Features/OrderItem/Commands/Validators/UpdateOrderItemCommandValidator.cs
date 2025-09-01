namespace RestaurantProject.Application.Features.OrderItem.Commands.Validators;
public class UpdateOrderItemCommandValidator : AbstractValidator<UpdateOrderItemCommand>
{
	public UpdateOrderItemCommandValidator()
	{
		RuleFor(x=>x.AddOrderItemRequest)
			.NotNull()
			.WithMessage("AddOrderItemRequest cannot be null")
			.SetValidator(new AddOrderItemRequestValidator());
	}
}
