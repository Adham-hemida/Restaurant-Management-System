using RestaurantProject.Application.Features.Table.Commands.Models;

namespace RestaurantProject.Application.Features.Table.Commands.Validators;
public class UpdateStatusOfTableCommandValidator : AbstractValidator<UpdateStatusOfTableCommand>
{
	public UpdateStatusOfTableCommandValidator()
	{
		RuleFor(x => x.Status)
			.NotEmpty()
			.WithMessage("Status is required")
			.Length(3,25);
	}
}
