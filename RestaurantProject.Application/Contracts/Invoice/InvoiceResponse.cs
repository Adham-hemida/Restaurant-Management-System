namespace RestaurantProject.Application.Contracts.Invoice;
public record InvoiceResponse(
	int Id,
	decimal TotalAmount,
	string PaymentMethod,
	decimal Tax,
	decimal ServiceCharge,
	decimal FinalAmount,
	InvoiceOfOrderResponse Order
);
