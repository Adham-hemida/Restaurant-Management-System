using RestaurantProject.Application.Features.Role.Commands.Models;

namespace RestaurantProject.Application.Features.Role.Commands.Validations;
public class AddRoleCommandsValidator : AbstractValidator<AddRoleCommands>
{
	public AddRoleCommandsValidator()
	{
		RuleFor(x=>x.RoleRequest)
			.NotNull()
			.WithMessage("Role request cannot be null.")
			.SetValidator(new RoleRequestValidator());
	}
}
