using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Contracts.Role;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IAuthentication;

namespace RestaurantProject.Infrastructure.Implementaion.Authentication;
public class RoleService(RoleManager<ApplicationRole> roleManager,
	IRoleClaimRepository roleClaimRepository) : IRoleService
{
	private readonly RoleManager<ApplicationRole> _roleManager = roleManager;
	private readonly IRoleClaimRepository _roleClaimRepository = roleClaimRepository;

	public async Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default)
	{
		return await _roleManager.Roles
			.Where(x => !x.IsDeleted || includeDisabled)
			.ProjectToType<RoleResponse>()
			.ToListAsync(cancellationToken);
	}

	public async Task<Result<RoleDetailResponse>> GetAsync(string id)
	{
		if (await _roleManager.FindByIdAsync(id) is not { } role)
			return Result.Failure<RoleDetailResponse>(RolesError.RoleNotFound);

		var permissions = await _roleManager.GetClaimsAsync(role);

		var response = new RoleDetailResponse(role.Id, role.Name!, role.IsDeleted, permissions.Select(x => x.Value!));
		return Result.Success(response);
	}


	public async Task<Result<RoleDetailResponse>> AddAsync(RoleRequest request)
	{
		var roleIsExist = await _roleManager.RoleExistsAsync(request.Name);

		if (roleIsExist)
			return Result.Failure<RoleDetailResponse>(RolesError.RoleDuplicated);

		var allowedPermissions = Permissions.GetAllPermissions();

		if (request.Permissions.Except(allowedPermissions).Any())
			return Result.Failure<RoleDetailResponse>(RolesError.InvalidPermissions);

		var role = new ApplicationRole
		{
			Name = request.Name,
			ConcurrencyStamp = Guid.CreateVersion7().ToString()
		};

		var result = await _roleManager.CreateAsync(role);
		if (result.Succeeded)
		{
			var permissions = request.Permissions
				.Select(x => new IdentityRoleClaim<string>
				{
					ClaimType = Permissions.Type,
					ClaimValue = x,
					RoleId = role.Id
				});

			await _roleClaimRepository.AddClaimsAsync(permissions);
			var response = new RoleDetailResponse(role.Id, role.Name, role.IsDeleted, request.Permissions);
			return Result.Success(response);
		}
		else
		{
			var errors = result.Errors.First();
			return Result.Failure<RoleDetailResponse>(new Error(errors.Code, errors.Description, StatusCodes.Status400BadRequest));
		}
	}

	public async Task<Result> UpdateAsync(string id, RoleRequest request)
	{
		if (await _roleManager.FindByIdAsync(id) is not { } role)
			return Result.Failure(RolesError.RoleNotFound);

		var roleIsExist = await _roleManager.Roles.AnyAsync(x => x.Name == request.Name && x.Id != id);
		if (roleIsExist)
			return Result.Failure(RolesError.RoleDuplicated);

		var allowedPermissions = Permissions.GetAllPermissions();

		if (request.Permissions.Except(allowedPermissions).Any())
			return Result.Failure<RoleDetailResponse>(RolesError.InvalidPermissions);

		role.Name = request.Name;
		var result = await _roleManager.UpdateAsync(role);

		if (result.Succeeded)
		{
			var currentPermissions = await _roleClaimRepository.GetClaimsOfRoleAsync(role.Id);

			var newPermissions = request.Permissions.Except(currentPermissions)
				.Select(x => new IdentityRoleClaim<string>
				{
					ClaimType = Permissions.Type,
					ClaimValue = x,
					RoleId = id
				});

			var removedPermissions = currentPermissions.Except(request.Permissions);

			await _roleClaimRepository.RemoveClaimsAsync(id, removedPermissions);

			await _roleClaimRepository.AddClaimsAsync(newPermissions);
			return Result.Success();
		}
		else
		{
			var errors = result.Errors.First();
			return Result.Failure(new Error(errors.Code, errors.Description, StatusCodes.Status400BadRequest));
		}
	}

	public async Task<Result> ToggleStatusAsync(string id)
	{
		var role = await _roleManager.FindByIdAsync(id);
		if (role is null)
			return Result.Failure(RolesError.RoleNotFound);
		role.IsDeleted = !role.IsDeleted;
		await _roleManager.UpdateAsync(role);
		return Result.Success();

	}
}