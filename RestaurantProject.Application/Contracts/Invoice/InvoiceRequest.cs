namespace RestaurantProject.Application.Contracts.Invoice;
public record InvoiceRequest(
	decimal TaxPercentage,
	decimal ServiceCharge
	);