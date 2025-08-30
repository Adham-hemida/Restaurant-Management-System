namespace RestaurantProject.Application.Contracts.Table;
public record TableResponse(
	int Id,
	int TableNumber,
	int SeatsCount,
	string Status
	);
