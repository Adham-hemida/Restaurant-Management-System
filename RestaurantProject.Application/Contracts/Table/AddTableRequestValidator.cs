using RestaurantProject.Domain.Consts;

namespace RestaurantProject.Application.Contracts.Table;
public class AddTableRequestValidator : AbstractValidator<AddTableRequest>
{
	public AddTableRequestValidator()
	{
		RuleFor(x => x.TableNumber)
			.NotEmpty()
			.WithMessage("Table number is required.")
			.GreaterThan(0)
			.WithMessage("Table number must be greater than 0.");

		RuleFor(x => x.SeatsCount)
			.NotEmpty()
			.WithMessage("Seats count is required.")
			.GreaterThan(0)
			.WithMessage("Seats count must be greater than 0.");

  
    }
}
