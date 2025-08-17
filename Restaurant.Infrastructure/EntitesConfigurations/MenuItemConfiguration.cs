using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
{
	public void Configure(EntityTypeBuilder<MenuItem> builder)
	{
		builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
		builder.Property(x => x.Price).HasColumnType("decimal(18,2)").IsRequired();
		builder.Property(x => x.Description).HasMaxLength(500);
		builder.HasIndex(x => x.Name).IsUnique();

	}
}