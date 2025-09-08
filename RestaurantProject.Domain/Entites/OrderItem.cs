namespace RestaurantProject.Domain.Entites;
public class OrderItem : AuditableEntity
{
	public int Id { get; set; }

	public double Quantity { get; set; }
	public decimal UnitPrice { get; set; }
	public double? Discount { get; set; }
	public string? Notes { get; set; } = string.Empty;
	public decimal TotalPrice { get; set; }
	public bool IsActive { get; set; } = true;

	public int OrderId { get; set; }
	public Order Order { get; set; } = default!;
	public int MenuItemId { get; set; }
	public MenuItem MenuItem { get; set; } = default!;
}