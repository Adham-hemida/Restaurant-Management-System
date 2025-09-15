using Microsoft.AspNetCore.Identity;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Application.Contracts.Invoice;
public interface IRoleClaimRepository
{
	Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetUserRolesPermissions(ApplicationUser user, CancellationToken cancellationToken);
	Task RemoveClaimsAsync(string roleId, IEnumerable<string> claimValues, CancellationToken cancellationToken = default);
	Task AddClaimsAsync(IEnumerable<IdentityRoleClaim<string>> claims, CancellationToken cancellationToken = default);
	Task<List<string>> GetClaimsOfRoleAsync(string roleId);
}
