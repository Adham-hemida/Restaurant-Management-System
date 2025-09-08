namespace RestaurantProject.Application.Contracts.Order;
public record OrderRequest(
	string Name,
	int TableId,
	IEnumerable<OrderItemRequest> OrderItems
	);
