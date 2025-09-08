namespace RestaurantProject.Application.Contracts.Order;
public class UpdateOrderStatusRequestValidator : AbstractValidator<UpdateOrderStatusRequest>
{
	public UpdateOrderStatusRequestValidator()
	{
		RuleFor(x => x.Status)
            .NotEmpty()
            .WithMessage("Status is required")
            .Length(3, 25);
	}
}
