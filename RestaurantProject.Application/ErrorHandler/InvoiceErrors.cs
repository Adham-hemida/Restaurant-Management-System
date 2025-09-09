using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;
public static class InvoiceErrors
{
	public static readonly Error InvoiceNotFound =
new("Invoice.not_found", "No Invoice was found with the given Id", StatusCodes.Status404NotFound);

}
