using RestaurantProject.Application.Features.Table.Commands.Models;

namespace RestaurantProject.Application.Features.Table.Commands.Validators;
public class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
{
	public UpdateTableCommandValidator()
	{
		RuleFor(x=>x.UpdateTableRequest)
			.NotNull()
			.WithMessage("UpdateTableRequest is required")
			.SetValidator(new UpdateTableRequestValidator());
	
	}
}
