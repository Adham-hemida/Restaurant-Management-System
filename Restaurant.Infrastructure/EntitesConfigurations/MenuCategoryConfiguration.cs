using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class MenuCategoryConfiguration : IEntityTypeConfiguration<MenuCategory>
{
	public void Configure(EntityTypeBuilder<MenuCategory> builder)
	{
		builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
		builder.Property(x => x.Description).HasMaxLength(300);

		builder.HasIndex(x => x.Name).IsUnique();
	}
}