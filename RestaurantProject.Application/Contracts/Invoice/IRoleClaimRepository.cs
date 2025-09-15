using Microsoft.AspNetCore.Identity;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Application.Contracts.Invoice;
public interface IRoleClaimRepository
{
	Task<(IEnumerable<string> roles, IEnumerable<string> permissions)> GetUserRolesPermissions(ApplicationUser user, CancellationToken cancellationToken);
	Task AddClaimsAsync(IEnumerable<IdentityRoleClaim<string>> claims, CancellationToken cancellationToken = default);

}
