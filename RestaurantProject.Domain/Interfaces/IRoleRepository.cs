namespace RestaurantProject.Domain.Interfaces;
public interface IRoleRepository
{
	Task DeleteRolesOfUserAsync(string userId, CancellationToken cancellationToken);
}
