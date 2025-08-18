namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
	public void Configure(EntityTypeBuilder<Order> builder)
	{
		builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
		builder.Property(x => x.Status).IsRequired().HasMaxLength(20).HasDefaultValue("Pending");
		builder.Property(x => x.TotalAmount).HasColumnType("decimal(18,2)").IsRequired().HasDefaultValue(0);
	}
}