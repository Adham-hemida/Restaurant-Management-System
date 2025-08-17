using Microsoft.EntityFrameworkCore;
using RestaurantProject.Domain.Entites;
using System.Reflection;

namespace RestaurantProject.Infrastructure.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): DbContext(options)
{
	public DbSet<Invoice> Invoices { get; set; } = default!;
	public DbSet<MenuCategory> MenuCategorys { get; set; } = default!;
	public DbSet<MenuItem> MenuItems { get; set; } = default!;
	public DbSet<MenuItemRating> MenuItemRatings { get; set; } = default!;
	public DbSet<Order> Orders { get; set; } = default!;
	public DbSet<OrderItem> OrderItems { get; set; } = default!;
	public DbSet<Table> Tables { get; set; } = default!;
	public DbSet<UploadedFile> UploadedFiles { get; set; } = default!;
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(assembly: Assembly.GetExecutingAssembly());
		base.OnModelCreating(modelBuilder);

	}
}

