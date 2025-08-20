using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantProject.Domain.Repositories;
using RestaurantProject.Infrastructure.Implementaion.Repositories;

namespace RestaurantProject.Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));

		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		//services.AddScoped<IMenuCategoryService, MenuCategoryService>();
		services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();


		return services;
	}
}
