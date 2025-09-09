using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Features.Invoice.Commands.Models;

namespace RestaurantProject.Application.Features.Invoice.Commands.Validations;
public class UpdatePayMenthodCommandValidator : AbstractValidator<UpdatePayMenthodCommand>
{
	public UpdatePayMenthodCommandValidator()
	{
		RuleFor(x => x.PaymentMethodRequest)
			.NotNull()
			.WithMessage("Payment method request cannot be null.")
			.SetValidator(new UpdateInvoicePaymentMethodRequestValidator());
	}
}
