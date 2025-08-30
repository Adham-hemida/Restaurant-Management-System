using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;
public static class TableErrors
{
	public static readonly Error TableNotFound =
	new("Table.not_found", "No Table was found with the given Id", statusCode: StatusCodes.Status404NotFound);
}
