using RestaurantProject.Application.Contracts.Role;

namespace RestaurantProject.Application.Interfaces.IAuthentication;
public interface IRoleService
{
	Task<IEnumerable<RoleResponse>> GetAllAsync(bool includeDisabled = false, CancellationToken cancellationToken = default);
	Task<Result<RoleDetailResponse>> GetAsync(string id);

}
