using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;
public static class RolesError
{
	public static readonly Error RoleNotFound =
		new("Role.Notfound", "Role not found", StatusCodes.Status404NotFound);
}
