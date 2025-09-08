using RestaurantProject.Application.Features.Order.Commands.Models;

namespace RestaurantProject.Application.Features.Order.Commands.Validators;
public class UpdateStatusOfOrderCommandValidator : AbstractValidator<UpdateStatusOfOrderCommand>
{
	public UpdateStatusOfOrderCommandValidator()
	{
		RuleFor(x => x.StatusRequest)
           .NotNull()
		   .WithMessage("StatusRequest is required.")
		   .SetValidator(new UpdateOrderStatusRequestValidator());
	}
}
