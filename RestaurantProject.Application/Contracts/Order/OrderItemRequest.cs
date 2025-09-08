namespace RestaurantProject.Application.Contracts.Order;
public record OrderItemRequest(
	int MenuItemId,
	double Quantity,
	double? Discount,
	string? Notes
	);
