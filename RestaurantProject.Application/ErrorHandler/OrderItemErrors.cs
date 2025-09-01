using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;

public static class OrderItemErrors
{
	public static readonly Error OrderNotFound =
		new("OrderItem.not_found", "No OrderItem was found with the given Id", statusCode: StatusCodes.Status404NotFound);
	
	public static readonly Error NoOrderItemsFound =
		new("OrderItems.not_found", "No OrderItems was found ", statusCode: StatusCodes.Status404NotFound);

}