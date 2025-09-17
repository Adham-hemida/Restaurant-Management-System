using RestaurantProject.Application.Features.Dashboard.Queries.Models;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Validators;
public class GetTopMenuItemsQueryValidator : AbstractValidator<GetTopMenuItemsQuery>
{
	public GetTopMenuItemsQueryValidator()
	{
		RuleFor(x=>x.Date)
			.NotEmpty()
			.WithMessage("Date is required");
	}
}
