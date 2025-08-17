namespace RestaurantProject.Domain.Entites;
public class Invoice
{
	public int Id { get; set; }
	public decimal TotalAmount { get; set; }
	public string PaymentMethod { get; set; } = string.Empty;
	public DateTime? PaidAt { get; set; }
	public bool IsPaid { get; set; } = false;
	public bool IsActive { get; set; } = true;

	public int OrderId { get; set; }
	public Order Order { get; set; } = default!;
}
