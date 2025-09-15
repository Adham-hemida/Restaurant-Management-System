namespace RestaurantProject.Application.Contracts.Role;
public record RoleRequest (
	string Name,
	List<string> Permissions
);