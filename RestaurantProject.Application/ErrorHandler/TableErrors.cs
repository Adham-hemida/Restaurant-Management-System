using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;
public static class TableErrors
{
	public static readonly Error TableNotFound =
	    new("Table.not_found", "No Table was found with the given Id", statusCode: StatusCodes.Status404NotFound);
	
	public static readonly Error InvalidTableStatus =
	    new("TableStatus.not_Valid", " TableStatus is not correct ", statusCode: StatusCodes.Status400BadRequest);
	
	public static readonly Error DuplicatedTable =
		new("Table.Duplicated", " Another Table is already exist", StatusCodes.Status409Conflict);
	
	public static readonly Error TableNotAvailable =
		new("Table.NotAvailable", "  Table is Not Available", StatusCodes.Status400BadRequest);
}
