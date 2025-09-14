using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using RestaurantProject.API.OpenApiTransformers;
using RestaurantProject.Application.Settings;
using System.Text;
namespace RestaurantProject.API
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();

			services.AddBackgroundJobsConfig(configuration);
			services.AddHttpContextAccessor();

			services.AddOptions<MailSettings>()
		       .BindConfiguration(nameof(MailSettings))
		       .ValidateDataAnnotations()
		       .ValidateOnStart();

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
	}
}