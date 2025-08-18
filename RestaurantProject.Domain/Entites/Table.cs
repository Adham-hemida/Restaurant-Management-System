using RestaurantProject.Domain.Consts;

namespace RestaurantProject.Domain.Entites;
public class Table
{
	public int Id { get; set; }
	public int TableNumber { get; set; }
	public int SeatsCount { get; set; }
	public string Status { get; set; } = TableStatus.Available;

	public ICollection<Order> Orders { get; set; } = [];
	public string? UserId { get; set; } = string.Empty;
	public ApplicationUser? User { get; set; } = default!;

}
