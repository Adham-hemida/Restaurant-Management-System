using Mapster;
using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Role;
using RestaurantProject.Application.ErrorHandler;
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

	public async Task<Result<RoleDetailResponse>> GetAsync(string id)
	{
		if(await _roleManager.FindByIdAsync(id) is not { } role)
			return Result.Failure<RoleDetailResponse>(RolesError.RoleNotFound);

		var permissions= await _roleManager.GetClaimsAsync(role);

		var response = new RoleDetailResponse( role.Id, role.Name!, role.IsDeleted, permissions.Select(x => x.Value!));
		return Result.Success(response);
	}
}
