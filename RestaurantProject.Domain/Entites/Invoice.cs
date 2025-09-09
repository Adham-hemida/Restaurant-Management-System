namespace RestaurantProject.Domain.Entites;
public class Invoice : AuditableEntity
{
	public int Id { get; set; }
	public decimal TotalAmount { get; set; }
	public string PaymentMethod { get; set; } = string.Empty;
	public DateTime? PaidAt { get; set; }
	public bool IsPaid { get; set; } = false;
	public bool IsActive { get; set; } = true;
	public decimal TaxPercentage { get; set; } = 0;
	public decimal Tax { get; set; } = 0;
	public decimal ServiceCharge { get; set; } = 0;

	public decimal FinalAmount => TotalAmount + Tax + ServiceCharge;

	public int OrderId { get; set; }
	public Order Order { get; set; } = default!;

}
