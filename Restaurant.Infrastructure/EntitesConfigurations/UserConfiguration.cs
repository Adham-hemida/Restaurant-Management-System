using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Abstractions.Consts;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{

	public void Configure(EntityTypeBuilder<ApplicationUser> builder)
	{
		builder.Property(x => x.FirstName).HasMaxLength(100);
		builder.Property(x => x.LastName).HasMaxLength(100);

		builder.OwnsMany(x => x.RefreshTokens)
		.ToTable("RefreshTokens")
		.WithOwner()
		.HasForeignKey("UserId");

		builder.HasData(new ApplicationUser
		{
			Id = DefaultUsers.Admin.Id,
			FirstName = "Restaurant System",
			LastName = "Admin",
			UserName = DefaultUsers.Admin.Email,
			NormalizedUserName = DefaultUsers.Admin.Email.ToUpper(),
			Email = DefaultUsers.Admin.Email,
			NormalizedEmail = DefaultUsers.Admin.Email.ToUpper(),
			SecurityStamp = DefaultUsers.Admin.SecurityStamp,
			ConcurrencyStamp = DefaultUsers.Admin.ConcurrencyStamp,
			EmailConfirmed = true,
			PasswordHash = DefaultUsers.Admin.PasswordHash
		});

	}
}