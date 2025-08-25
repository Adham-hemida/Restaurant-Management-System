namespace RestaurantProject.Application.Contracts.MenuItem;
public record MenuItemRequest(
	string Name,
	string Description,
	decimal Price
	);
