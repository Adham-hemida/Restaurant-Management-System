namespace RestaurantProject.Application.Contracts.Invoice;
public class UpdateInvoicePaymentMethodRequestValidator : AbstractValidator<UpdateInvoicePaymentMethodRequest>
{
	public UpdateInvoicePaymentMethodRequestValidator()
	{
		RuleFor(x => x.PaymentMethod)
			.NotEmpty()
			.WithMessage("Payment method is required.")
			.MaximumLength(50)
			.WithMessage("max length  50 characters.");
	}
}
