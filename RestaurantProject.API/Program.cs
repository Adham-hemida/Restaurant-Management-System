using Hangfire;
using HangfireBasicAuthenticationFilter;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureDependencies(builder.Configuration);
builder.Services.AddApiDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies();

builder.Host.UseSerilog((context, configuration)
   => configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
	app.MapScalarApiReference();
}
app.UseSerilogRequestLogging();
app.UseHttpsRedirection();

app.UseHangfireDashboard("/jobs", new DashboardOptions
{
	Authorization = new[]
   {
	   new HangfireCustomBasicAuthenticationFilter
	   {
		   User = app.Configuration.GetValue<string>("HangfireSettings:Username"),
		   Pass = app.Configuration.GetValue<string>("HangfireSettings:Password")
	   }
   },
	DashboardTitle = "Restaurant System Jobs"
});

app.UseCors();
app.UseAuthorization();

app.MapControllers();
app.MapStaticAssets();
app.UseExceptionHandler();
app.Run();
