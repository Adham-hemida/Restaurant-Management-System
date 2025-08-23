namespace RestaurantProject.Application.Features.MenuCategory.Command.Validators;
public class UpdateMenuCategoryCommandValidator : AbstractValidator<UpdateMenuCategoryCommand>
{
	public UpdateMenuCategoryCommandValidator()
	{
		RuleFor(x => x.MenuCategoryRequest)
			.NotNull()
			.WithMessage("Menu category request cannot be null.")
			.SetValidator(new MenuCategoryRequestValidator());
	}
}
