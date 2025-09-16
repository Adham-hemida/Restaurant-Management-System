namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class RoleRepository( ApplicationDbContext context) : IRoleRepository
{
	private readonly ApplicationDbContext _context = context;

	public async Task DeleteRolesOfUserAsync(string  userId , CancellationToken cancellationToken)
	{
		 await _context.UserRoles
			.Where(x => x.UserId == userId)
			.ExecuteDeleteAsync(cancellationToken);
	}
}
