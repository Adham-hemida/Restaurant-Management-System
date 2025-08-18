using Microsoft.AspNetCore.Identity;

namespace RestaurantProject.Domain.Entites;
public class ApplicationUser : IdentityUser
{
	public ApplicationUser()
	{
		Id = Guid.CreateVersion7().ToString();
		SecurityStamp = Guid.CreateVersion7().ToString();

	}

	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public bool IsDisabled { get; set; }

	public ICollection<Order> Orders { get; set; } = [];
	public ICollection<Table> Tables { get; set; } = [];
	public ICollection<Invoice> Invoices { get; set; } = [];
	public ICollection<MenuItemRating> MenuItemRatings { get; set; } = [];

}
