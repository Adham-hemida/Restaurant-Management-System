namespace RestaurantProject.Application.Abstractions.Consts;
public static class DefaultRoles
{
	public partial class Admin
	{
		public const string Name = nameof(Admin);
		public const string Id = "019855ea-fef8-708d-ab80-da9e81d2325c";
		public const string ConcurrencyStamp = "019855ea-fef8-708d-ab80-da9f845c911f";
	}

	public partial class Manager
	{
		public const string Name = nameof(Manager);
		public const string Id = "019948be-4497-7530-9afd-ef7f0538bcea";
		public const string ConcurrencyStamp = "019948be-4497-7530-9afd-ef80b4f7fcd0";
	}
	public partial class Chef
	{
		public const string Name = nameof(Chef);
		public const string Id = "019855ea-fef8-708d-ab80-daa013145d98";
		public const string ConcurrencyStamp = "019855ea-fef8-708d-ab80-daa156960d15";
	}

	public partial class Waiter
	{
		public const string Name = nameof(Waiter);
		public const string Id = "01985a37-f9c5-7676-93c6-fd7259f4b646";
		public const string ConcurrencyStamp = "01985a37-f9c5-7676-93c6-fd73c880f710";
	}

	public partial class Cashier
	{
		public const string Name = nameof(Cashier);
		public const string Id = "01985a37-f9c5-7676-93c6-fd740ea964e2";
		public const string ConcurrencyStamp = "01985a37-f9c5-7676-93c6-fd75e1ce1428";
	}
	
	public partial class Staff
	{
		public const string Name = nameof(Staff);
		public const string Id = "019948be-4497-7530-9afd-ef81fb3b2312";
		public const string ConcurrencyStamp = "019948be-4497-7530-9afd-ef82debc832c";
	}
	
}
