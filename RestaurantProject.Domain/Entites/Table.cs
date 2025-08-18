using RestaurantProject.Domain.Consts;

namespace RestaurantProject.Domain.Entites;
public class Table : AuditableEntity
{
	public int Id { get; set; }
	public int TableNumber { get; set; }
	public int SeatsCount { get; set; }
	public string Status { get; set; } = TableStatus.Available;

	public ICollection<Order> Orders { get; set; } = [];

}
