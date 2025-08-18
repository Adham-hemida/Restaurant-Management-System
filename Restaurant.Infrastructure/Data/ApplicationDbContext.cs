using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Application.Extensions;
using RestaurantProject.Domain.Entites;
using System.Reflection;

namespace RestaurantProject.Infrastructure.Data;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) 
	: IdentityDbContext<ApplicationUser>(options)
{
	private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

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

		var cascadeFks = modelBuilder.Model
			.GetEntityTypes()
			.SelectMany(t => t.GetForeignKeys())
			.Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);
		foreach (var fk in cascadeFks)
			fk.DeleteBehavior = DeleteBehavior.Restrict;

		base.OnModelCreating(modelBuilder);

	}

	public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		var entries = ChangeTracker.Entries<AuditableEntity>();
		foreach (var entry in entries)
		{
			var currentUserId = _httpContextAccessor.HttpContext?.User.GetUserId();
			if (entry.State == EntityState.Added)
			{
				entry.Property(x => x.CreatedById).CurrentValue = currentUserId!;

			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Property(x => x.UpdatedById).CurrentValue = currentUserId;
				entry.Property(x => x.UpdatedOn).CurrentValue = DateTime.UtcNow;
			}
		}
		return base.SaveChangesAsync(cancellationToken);
	}
}

