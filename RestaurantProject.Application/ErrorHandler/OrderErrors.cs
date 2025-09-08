using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;
public static class OrderErrors
{
	public static readonly Error OrderNotFound =
		new("Order.not_found", "No Order was found with the given Id", statusCode: StatusCodes.Status404NotFound);
	
	public static readonly Error OrderCannotBeModified =
		new("Order.CannotBeModified", "Order can not modified", statusCode: StatusCodes.Status400BadRequest);
	
	public static readonly Error OrderNotCompleted =
		new("Order.NotCompleted", "Order Not Completed yet", statusCode: StatusCodes.Status400BadRequest);


}
