using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class TableConfiguration : IEntityTypeConfiguration<Table>
{
	public void Configure(EntityTypeBuilder<Table> builder)
	{
		builder.Property(x => x.TableNumber).IsRequired();
		builder.Property(x => x.SeatsCount).IsRequired();
		builder.Property(x => x.Status).HasMaxLength(20).IsRequired().HasDefaultValue("Available");


	}
}