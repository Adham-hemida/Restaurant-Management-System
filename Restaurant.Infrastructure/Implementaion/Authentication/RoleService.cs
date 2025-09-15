using Mapster;
using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Contracts.Role;
using RestaurantProject.Application.Interfaces.IAuthentication;

namespace RestaurantProject.Infrastructure.Implementaion.Authentication;
public class RoleService(RoleManager<ApplicationRole> roleManager) : IRoleService
{
	private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

	public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default)
	{
		return await _roleManager.Roles
			.Where(x => !x.IsDeleted || includeDisabled)
			.ProjectToType<RoleResponse>()
			.ToListAsync(cancellationToken);
	}
}
