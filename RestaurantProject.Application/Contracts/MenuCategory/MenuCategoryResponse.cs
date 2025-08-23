namespace RestaurantProject.Application.Contracts.MenuCategory;
public record MenuCategoryResponse(
	int Id,
	string Name,
	string Description,
	bool IsActive
	);
