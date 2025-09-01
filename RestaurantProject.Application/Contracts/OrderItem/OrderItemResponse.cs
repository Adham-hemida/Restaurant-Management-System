namespace RestaurantProject.Application.Contracts.OrderItem;
public record OrderItemResponse(
	int Id,
	double Quantity,
	decimal UnitPrice,
	double? Discount,
	string? Notes,
	decimal TotalPrice
	);
