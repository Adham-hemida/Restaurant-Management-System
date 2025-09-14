using Microsoft.AspNetCore.Authorization;

namespace RestaurantProject.Infrastructure.Permission;
public class PermissionRequirement(string permission) : IAuthorizationRequirement
{
	public string Permission { get; } = permission;
}