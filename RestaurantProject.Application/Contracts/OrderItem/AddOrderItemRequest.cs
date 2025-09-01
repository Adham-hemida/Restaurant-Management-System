namespace RestaurantProject.Application.Contracts.OrderItem;
public record AddOrderItemRequest(
	double Quantity,
	double? Discount,
	string? Notes
	);
