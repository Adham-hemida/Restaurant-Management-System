using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Validators;
public class AddOrderCommandValidator : AbstractValidator<AddOrderCommand>
{
	public AddOrderCommandValidator()
	{
		RuleFor(x => x.OrderRequest)
			   .NotNull()
			   .WithMessage("OrderRequest is required.")
			   .SetValidator(new OrderRequestValidator());
	}
}
