using Microsoft.Extensions.DependencyInjection;
using RestaurantProject.Application.ExceptionHandler;

namespace RestaurantProject.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
	{
		services.AddExceptionHandler<GlobalExceptionHandler>();
		services.AddProblemDetails();

		return services;
	}
}