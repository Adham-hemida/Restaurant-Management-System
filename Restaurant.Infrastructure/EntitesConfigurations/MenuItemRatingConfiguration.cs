namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class MenuItemRatingConfiguration : IEntityTypeConfiguration<MenuItemRating>
{
	public void Configure(EntityTypeBuilder<MenuItemRating> builder)
	{
		builder.Property(x => x.Comment).HasMaxLength(500);

	
	}
}