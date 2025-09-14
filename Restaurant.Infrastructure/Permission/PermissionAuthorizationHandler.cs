using Microsoft.AspNetCore.Authorization;
using RestaurantProject.Application.Abstractions.Consts;

namespace RestaurantProject.Infrastructure.Permission;
public class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
	protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
	{
		//var user = context.User.Identity;
		//if (user is null || !user.IsAuthenticated)
		//	return;
		//var hasPermission =context.User.Claims.Any(x=>x.Value == requirement.Permission && x.Type == Permissions.Type);
		//if (hasPermission)
		//{
		//	context.Succeed(requirement);
		//	return;
		//}
		//return;

		if (context.User.Identity is not { IsAuthenticated: true } ||
			!context.User.Claims.Any(x => x.Value == requirement.Permission && x.Type == Permissions.Type))
			return;
		context.Succeed(requirement);
		return;
	}
}