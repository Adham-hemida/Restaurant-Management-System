using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Features.Invoice.Commands.Models;

namespace RestaurantProject.Application.Features.Invoice.Commands.Validations;
public class AddInvoiceCommandValidator : AbstractValidator<AddInvoiceCommand>
{
	public AddInvoiceCommandValidator()
	{
		RuleFor(x => x.InvoiceRequest)
			.NotNull()
			.WithMessage("InvoiceRequest is required.")
			.SetValidator(new InvoiceRequestValidator());
		
	}
}
