namespace RestaurantProject.Application.Contracts.Invoice;
public class InvoiceRequestValidator : AbstractValidator<InvoiceRequest>
{
	public InvoiceRequestValidator()
	{
		RuleFor(x => x.TaxPercentage)
			.GreaterThanOrEqualTo(0)
			.WithMessage("TaxPercentage must be 0 or greater")
			.LessThanOrEqualTo(100)
			.WithMessage("TaxPercentage should be less or equal than 100");

		RuleFor(x => x.ServiceCharge)
			.GreaterThanOrEqualTo(0)
			.WithMessage("ServiceCharge must be 0 or greater");
	}
}
