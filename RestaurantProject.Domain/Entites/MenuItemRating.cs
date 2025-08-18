namespace RestaurantProject.Domain.Entites;
public class MenuItemRating : AuditableEntity
{
	public int Id { get; set; }

	public int Rating { get; set; }
	public string Comment { get; set; } = string.Empty;

	
	public int MenuItemId { get; set; }
	public MenuItem MenuItem { get; set; } = default!;

	public int OrderId { get; set; }
	public Order Order { get; set; } = default!;


}

