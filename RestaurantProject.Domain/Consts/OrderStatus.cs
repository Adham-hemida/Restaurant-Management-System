namespace RestaurantProject.Domain.Consts;
public static class OrderStatus
{
	public const string Pending = "Pending";
	public const string InProgress = "InProgress";
	public const string Completed = "Completed";
	public const string Cancelled = "Cancelled";

	public static IList<string?> GetAllOrdersStatus() =>
		typeof(OrderStatus).GetFields().Select(x => x.GetValue(x) as string).ToList();
}
