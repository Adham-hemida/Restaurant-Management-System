using RestaurantProject.Domain.Consts;

namespace RestaurantProject.Domain.Entites;
public class Order
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public string Status { get; set; } = OrderStatus.Pending;
	public decimal TotalAmount { get; set; }
	public bool IsDelivered { get; set; } = false;
	public bool IsActive { get; set; } = true;


	public int TableId { get; set; }
	public Table Table { get; set; } = default!;
	public ICollection<OrderItem> OrderItems { get; set; } = [];
	public Invoice Invoice { get; set; } = default!;
}