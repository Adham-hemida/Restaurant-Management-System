namespace RestaurantProject.Application.Features.MenuCategory.Command.Validators;

public class AddMenuCategoryCommandValidator : AbstractValidator<AddMenuCategoryCommand>
{
	public AddMenuCategoryCommandValidator()
	{
		RuleFor(x=>x.MenuCategoryRequest)
			.NotNull()
			.WithMessage("Menu category request cannot be null.")
			.SetValidator(new MenuCategoryRequestValidator());
	}
}
