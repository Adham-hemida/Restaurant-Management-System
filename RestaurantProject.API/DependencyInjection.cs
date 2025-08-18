namespace RestaurantProject.API
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddHttpContextAccessor();

			return services;
		}
	}
}