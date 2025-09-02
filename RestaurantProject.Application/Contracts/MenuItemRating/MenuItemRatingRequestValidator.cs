namespace RestaurantProject.Application.Contracts.MenuItemRating;
public class MenuItemRatingRequestValidator : AbstractValidator<MenuItemRatingRequest>
{
	public MenuItemRatingRequestValidator()
	{
		RuleFor(x=>x.Rating)
			.NotEmpty()
			.WithMessage("Rating is required.")
			.InclusiveBetween(1, 5)
			.WithMessage("Rating must be between 1 and 5.");

		RuleFor(x => x.Comment)
			.MaximumLength(500)
			.WithMessage("Comment must not exceed 500 characters.");
	}
}
