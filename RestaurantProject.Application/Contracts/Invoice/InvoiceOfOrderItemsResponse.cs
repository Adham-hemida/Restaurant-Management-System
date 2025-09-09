namespace RestaurantProject.Application.Contracts.Invoice;
public record InvoiceOfOrderItemsResponse(
	string Name,
	double Quantity,
	decimal TotalPrice
	);