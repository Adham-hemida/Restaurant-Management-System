using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Application.Contracts.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class RoleClaimRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
	: IRoleClaimRepository
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly ApplicationDbContext _context = context;

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
}
