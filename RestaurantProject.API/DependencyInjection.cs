using RestaurantProject.Application.Settings;

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

			services.AddOptions<JwtOptions>()
		      .Bind(configuration.GetSection(JwtOptions.sectionName))
		      .ValidateDataAnnotations()
		      .ValidateOnStart();

			return services;
		}
	}
}