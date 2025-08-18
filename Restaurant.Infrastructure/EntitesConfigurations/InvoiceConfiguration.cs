namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
	public void Configure(EntityTypeBuilder<Invoice> builder)
	{

		builder.Property(x => x.TotalAmount)
			.IsRequired()
			.HasColumnType("decimal(18,2)");


		builder.Property(x => x.PaymentMethod).IsRequired().HasMaxLength(20);


	}
}