using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantProject.API.OpenApiTransformers;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Settings;
using RestaurantProject.Infrastructure.Permission;
using System.Text;
using System.Threading.RateLimiting;
namespace RestaurantProject.API
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			var allowOrigins = configuration.GetSection("AllowOrigins").Get<string[]>();

			services.AddCors(options =>
			options.AddDefaultPolicy(bulider =>
			{
				bulider.AllowAnyMethod()
				.AllowAnyHeader()
				.WithOrigins(allowOrigins!);
			}));


			services.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddBackgroundJobsConfig(configuration)
				.AddRatingLimitConfig();

			services.AddHealthChecks()
				 .AddSqlServer(name: "database", connectionString: configuration.GetConnectionString("DefaultConnection")!);


			services.AddHttpContextAccessor();

			services.AddOptions<MailSettings>()
			   .BindConfiguration(nameof(MailSettings))
			   .ValidateDataAnnotations()
			   .ValidateOnStart();

			services.AddTransient<IAuthorizationHandler, PermissionAuthorizationHandler>();
			services.AddTransient<IAuthorizationPolicyProvider, PermissionAuthorizationPolicyProvider>();

			services.AddOptions<JwtOptions>()
				.Bind(configuration.GetSection(JwtOptions.sectionName))
				.ValidateDataAnnotations()
				 .ValidateOnStart();

			var JwtSettings = configuration.GetSection(JwtOptions.sectionName).Get<JwtOptions>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

			})
				.AddJwtBearer(o =>
				{
					o.SaveToken = true;
					o.TokenValidationParameters = new TokenValidationParameters
					{
						ValidateIssuerSigningKey = true,
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidIssuer = JwtSettings?.Issuer,
						ValidAudience = JwtSettings?.Audience,
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings?.Key!))
					};
				});

			services.Configure<IdentityOptions>(options =>
			{
				options.Password.RequiredLength = 8;
				options.User.RequireUniqueEmail = true;
				options.SignIn.RequireConfirmedEmail = true;
			});

			services.AddOpenApi(options =>
			{
				options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
			});


			return services;
		}

		private static IServiceCollection AddBackgroundJobsConfig(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddHangfire(config => config
			   .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
			   .UseSimpleAssemblyNameTypeSerializer()
			   .UseRecommendedSerializerSettings()
			   .UseSqlServerStorage(configuration.GetConnectionString("HangfireConnect")));

			services.AddHangfireServer();

			return services;
		}


		private static IServiceCollection AddRatingLimitConfig(this IServiceCollection services)
		{
			services.AddRateLimiter(rateLimitterOptions =>
			{
				rateLimitterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

				rateLimitterOptions.AddPolicy(RateLimiters.IpLimiter, httpContext =>
				RateLimitPartition.GetFixedWindowLimiter(
					partitionKey: httpContext.Connection.RemoteIpAddress?.ToString(),
					factory: _ => new FixedWindowRateLimiterOptions
					{
						PermitLimit = 2,
						Window = TimeSpan.FromSeconds(20)
					}
				));

				rateLimitterOptions.AddFixedWindowLimiter(RateLimiters.FixedWindow, options =>
				{
					options.Window = TimeSpan.FromSeconds(10); 
					options.PermitLimit = 10;    
					options.QueueLimit = 5;
					options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
				});
			});
			return services;
		}
	}
}