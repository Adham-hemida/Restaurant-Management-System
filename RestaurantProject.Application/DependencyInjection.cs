using Mapster;
using FluentValidation;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using RestaurantProject.Application.ExceptionHandler;
using System.Reflection;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

namespace RestaurantProject.Application;
public static class DependencyInjection
{
	public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
	{
		services.AddExceptionHandler<GlobalExceptionHandler>();
		services.AddProblemDetails();

		var mappingConfig = TypeAdapterConfig.GlobalSettings;
		mappingConfig.Scan(Assembly.GetExecutingAssembly());
		services.AddSingleton<IMapper>(new Mapper(mappingConfig));

		services
			.AddFluentValidationAutoValidation()
			.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		services.AddMediatR(med => med.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));


		return services;
	}
}