namespace RestaurantProject.Application.Contracts.Table;
public record AddTableRequest(
	int TableNumber,
	int SeatsCount
	);
