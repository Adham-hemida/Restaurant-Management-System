using Microsoft.AspNetCore.Identity;

namespace RestaurantProject.Domain.Entites;
public class ApplicationRole : IdentityRole
{
	public ApplicationRole()
	{
		Id = Guid.CreateVersion7().ToString();
	}
	public bool IsDeleted { get; set; }
}
