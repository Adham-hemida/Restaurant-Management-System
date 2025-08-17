namespace RestaurantProject.Domain.Entites;
public class MenuItem
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public decimal Price { get; set; }
	public bool IsActive { get; set; } = true;


	public int CategoryId { get; set; }
	public MenuCategory Category { get; set; } = default!;
	public ICollection<OrderItem> OrderItems { get; set; } = [];

	public ICollection<MenuItemRating> MenuItemRatings { get; set; } = [];

	public ICollection<UploadedFile> UploadedFiles { get; set; } = [];
}