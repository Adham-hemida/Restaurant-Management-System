using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Invoice;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class RoleClaimRepository(UserManager<ApplicationUser> userManager,
	ApplicationDbContext context,
	RoleManager<ApplicationRole> roleManager)
	: IRoleClaimRepository
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly ApplicationDbContext _context = context;
	private readonly RoleManager<ApplicationRole> _roleManager = roleManager;

	public async Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetUserRolesPermissions(ApplicationUser user, CancellationToken cancellationToken)
	{
		var userRoles = await _userManager.GetRolesAsync(user);

		var userPermissions = await (
			from r in _context.Roles
			join p in _context.RoleClaims
			on r.Id equals p.RoleId
			where userRoles.Contains(r.Name!)
			select p.ClaimValue!)
			.Distinct()
			.ToListAsync(cancellationToken);

		return (userRoles, userPermissions);
	}

	public async Task AddClaimsAsync(IEnumerable<IdentityRoleClaim<string>> claims, CancellationToken cancellationToken = default)
	{
		await _context.RoleClaims.AddRangeAsync(claims, cancellationToken);
		await _context.SaveChangesAsync(cancellationToken);
	}

	public async Task RemoveClaimsAsync(string roleId, IEnumerable<string> claimValues, CancellationToken cancellationToken = default)
	{
		await _context.RoleClaims
			.Where(x => x.RoleId == roleId && claimValues.Contains(x.ClaimValue))
			.ExecuteDeleteAsync(cancellationToken);
	}

	public async Task<List<string>> GetClaimsOfRoleAsync(string roleId)
	{
		var role = await _roleManager.FindByIdAsync(roleId);

		var currentPermissions = await _context.RoleClaims
					.Where(x => x.RoleId == role!.Id && x.ClaimType == Permissions.Type)
					.Select(x => x.ClaimValue)
					.ToListAsync();

		return currentPermissions!;
	}
}
