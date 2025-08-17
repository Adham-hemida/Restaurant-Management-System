namespace RestaurantProject.Domain.Entites;
public class MenuCategory
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public bool IsActive { get; set; } = true;

	public ICollection<MenuItem> MenuItems { get; set; } = [];
}