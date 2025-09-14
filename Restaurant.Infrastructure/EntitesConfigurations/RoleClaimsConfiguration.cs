using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Abstractions.Consts;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class RoleClaimsConfiguration : IEntityTypeConfiguration<IdentityRoleClaim<string>>
{
	public void Configure(EntityTypeBuilder<IdentityRoleClaim<string>> builder)
	{
		// Default Data
		var permissions = Permissions.GetAllPermissions();
		var adminClaims = new List<IdentityRoleClaim<string>>();
		for (int i = 0; i < permissions.Count; i++)
		{
			adminClaims.Add(new IdentityRoleClaim<string>
			{
				Id = i + 1,
				RoleId = DefaultRoles.Admin.Id,
				ClaimType = Permissions.Type,
				ClaimValue = permissions[i]
			});

		}
		builder.HasData(adminClaims);
	}
}