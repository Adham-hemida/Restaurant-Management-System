using FluentValidation;

namespace RestaurantProject.Application.Contracts.MenuCategory;
public class MenuCategoryRequestValidator : AbstractValidator<MenuCategoryRequest>
{
	public MenuCategoryRequestValidator()
	{

		RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
			.MaximumLength(50)
			.WithMessage("Name should be  50 characters.");

		RuleFor(x => x.Description)
			.NotEmpty()
			.WithMessage("Description is required.")
			.MaximumLength(300)
			.WithMessage("Description should be 300 characters.");
	}
}
