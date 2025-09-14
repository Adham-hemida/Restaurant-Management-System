using Microsoft.AspNetCore.Authorization;

namespace RestaurantProject.Infrastructure.Permission;
public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{
}