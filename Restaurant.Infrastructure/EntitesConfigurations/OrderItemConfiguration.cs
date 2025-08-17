using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
	public void Configure(EntityTypeBuilder<OrderItem> builder)
	{
		builder.Property(x => x.Quantity).IsRequired();
		builder.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
		builder.Property(x => x.Notes).HasMaxLength(300);
		builder.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)").IsRequired();
	}
}
