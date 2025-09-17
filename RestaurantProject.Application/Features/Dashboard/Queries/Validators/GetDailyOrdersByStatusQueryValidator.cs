using RestaurantProject.Application.Features.Dashboard.Queries.Models;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Validators;
public class GetDailyOrdersByStatusQueryValidator : AbstractValidator<GetDailyOrdersByStatusQuery>
{
	public GetDailyOrdersByStatusQueryValidator()
	{
		RuleFor(x => x.Date)
	      .NotEmpty()
	      .WithMessage("Date is required");
	}
}
