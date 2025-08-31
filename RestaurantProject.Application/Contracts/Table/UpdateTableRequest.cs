namespace RestaurantProject.Application.Contracts.Table;

public record UpdateTableRequest(
	int TableNumber,
	int SeatsCount,
	string Status
	);
