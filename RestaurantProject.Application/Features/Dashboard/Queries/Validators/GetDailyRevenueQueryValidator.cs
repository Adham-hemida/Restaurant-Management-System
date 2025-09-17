using RestaurantProject.Application.Features.Dashboard.Queries.Models;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Validators;
public class GetDailyRevenueQueryValidator : AbstractValidator<GetDailyRevenueQuery>
{
	public GetDailyRevenueQueryValidator()
	{
		RuleFor(x => x.Date)
			.NotEmpty()
			.WithMessage("Date is required");
	}
}
