namespace RestaurantProject.Domain.Consts;
public static class TableStatus
{
	public const string Available = "Available";
	public const string Occupied = "Occupied";
	public const string Reserved = "Reserved";
	public const string Unavailable = "Unavailable";

	public static IList<string?> GetAllTablesStatus() =>
	typeof(TableStatus).GetFields().Select(x => x.GetValue(x) as string).ToList();

}
