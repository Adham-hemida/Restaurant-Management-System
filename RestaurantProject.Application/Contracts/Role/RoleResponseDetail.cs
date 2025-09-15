namespace RestaurantProject.Application.Contracts.Role;
public record RoleDetailResponse(
	string Id,
	string Name,
	bool IsDeleted,
	IEnumerable<string> Permissions
);