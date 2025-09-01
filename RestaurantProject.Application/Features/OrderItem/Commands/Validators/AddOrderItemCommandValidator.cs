using RestaurantProject.Application.Features.OrderItem.Commands.Models;

namespace RestaurantProject.Application.Features.OrderItem.Commands.Validators;
public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
{
	public AddOrderItemCommandValidator()
	{
		RuleFor(x=>x.AddOrderItemRequest)
			.NotNull()
			.WithMessage("AddOrderItemRequest is required")
			.SetValidator(new AddOrderItemRequestValidator());
	}
}
