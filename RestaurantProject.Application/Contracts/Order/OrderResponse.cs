namespace RestaurantProject.Application.Contracts.Order;
public record OrderResponse(
	int Id,
	string Name,
	string Status,
	decimal TotalAmount,
	bool IsDelivered,
	int TableNumber,
	IEnumerable<OrderItemMinimalResponse> OrderItems
	);
