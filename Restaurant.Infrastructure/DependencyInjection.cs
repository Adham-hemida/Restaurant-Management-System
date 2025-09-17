using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Interfaces.IAuthentication;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Interfaces;
using RestaurantProject.Domain.Repositories;
using RestaurantProject.Infrastructure.Implementaion.Authentication;
using RestaurantProject.Infrastructure.Implementaion.Repositories;
using RestaurantProject.Infrastructure.Implementaion.Services;

namespace RestaurantProject.Infrastructure;
public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection")
			?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

		services.AddDbContext<ApplicationDbContext>(options =>
			options.UseSqlServer(connectionString));

		services.AddHttpContextAccessor();

		services.AddSingleton<IJwtProvider, JwtProvider>();

		services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		services.AddScoped<IMenuCategoryRepository, MenuCategoryRepository>();
		services.AddScoped<IMenuItemRepository, MenuItemRepository>();
		services.AddScoped<IUploadedFileRepository, UploadedFileRepository>();
		services.AddScoped<ITableRepository, TableRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IOrderItemRepository, OrderItemRepository>();
		services.AddScoped<IMenuItemRatingRepository, MenuItemRatingRepository>();
		services.AddScoped<IOrderRepository, OrderRepository>();
		services.AddScoped<IInvoiceRepository, InvoiceRepository>();
		services.AddScoped<IRoleClaimRepository, RoleClaimRepository>();
		services.AddScoped<IRoleRepository, RoleRepository>();

		services.AddScoped<IMenuCategoryService, MenuCategoryService>();
		services.AddScoped<IMenuItemService, MenuItemService>();
		services.AddScoped<IAuthService, AuthService>();
		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IFileService, FileService>();
		services.AddScoped<ITableService, TableService>();
		services.AddScoped<IOrderItemService, OrderItemService>();
		services.AddScoped<IMenuItemRatingService, MenuItemRatingService>();
		services.AddScoped<IOrderService, OrderService>();
		services.AddScoped<IInvoiceService, InvoiceService>();
		services.AddScoped<IEmailSender, EmailService>();
		services.AddScoped<IRoleService, RoleService>();
		services.AddScoped<IDashboardService, DashboardService>();


		return services;
	}
}
