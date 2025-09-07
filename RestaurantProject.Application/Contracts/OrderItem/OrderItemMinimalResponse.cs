namespace RestaurantProject.Application.Contracts.OrderItem;
public record OrderItemMinimalResponse(
	int Id,
	double Quantity,
	string? Notes,
	decimal UnitPrice);
