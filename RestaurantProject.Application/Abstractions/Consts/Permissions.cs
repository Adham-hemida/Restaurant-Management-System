namespace RestaurantProject.Application.Abstractions.Consts;
public static class Permissions
{
	public static string Type { get; } = "permissions";

	public const string GetOrders = "orders:read";
	public const string AddOrders = "orders:add";
	public const string UpdateOrders = "orders:update";
	public const string ToggleDeliveredOrders = "orders:toggleDelivered";
	public const string MoveOrderToTable = "orders:moveToTable";

	public const string GetOrderItems = "orderItems:read";
	public const string AddOrderItems = "orderItems:add";
	public const string UpdateOrderItems = "orderItems:update";
	public const string DeleteOrderItems = "orderItems:delete";	
	
	public const string GetTables = "tables:read";
	public const string AddTables = "tables:add";
	public const string UpdateTables = "tables:update";
	
	public const string GetMenuItems = "menuItems:read";
	public const string AddMenuItems = "menuItems:add";
	public const string UpdateMenuItems = "menuItems:update";
	
	public const string GetMenuItemRatings = "menuItemRatings:read";
	public const string AddMenuItemRatings = "menuItemRatings:add";
	public const string UpdateMenuItemRatings = "menuItemRatings:update";
	
	public const string GetMenuCategories = "menuCategories:read";
	public const string AddMenuCategories = "menuCategories:add";
	public const string UpdateMenuCategories = "menuCategories:update";
	
	public const string GetInvoices = "invoices:read";
	public const string AddInvoices = "invoices:add";
	public const string UpdateInvoices = "invoices:update";


	public const string UploadFiles = "files:add";

	public const string GetUsers = "users:read";
	public const string AddUsers = "users:add";
	public const string UpdateUsers = "users:update";

	public const string GetRoles = "roles:read";
	public const string AddRoles = "roles:add";
	public const string UpdateRoles = "roles:update";

	public const string Results = "results:read";

	public static IList<string?> GetAllPermissions() =>
		typeof(Permissions).GetFields().Select(x => x.GetValue(x) as string).ToList();
}
