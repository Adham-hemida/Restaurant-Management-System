namespace RestaurantProject.Application.Contracts.Invoice;
public record InvoiceOfOrderResponse(
	int Id,
	string Name,
	IEnumerable<InvoiceOfOrderItemsResponse> OrderItems
	);
