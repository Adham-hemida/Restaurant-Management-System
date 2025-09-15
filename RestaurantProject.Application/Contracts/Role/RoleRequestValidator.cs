namespace RestaurantProject.Application.Contracts.Role;
public class RoleRequestValidator : AbstractValidator<RoleRequest>
{
	public RoleRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotEmpty()
			.Length(3, 100);

		RuleFor(x => x.Permissions)
			.NotNull()
			.NotEmpty()
			.WithMessage("permissions must not be empty");

		RuleFor(x => x.Permissions)
			.Must(x => x.Distinct().Count() == x.Count)
			.WithMessage("Duplicate permissions are not allowed")
			.When(x => x.Permissions != null);

	}
}