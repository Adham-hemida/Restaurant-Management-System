using Microsoft.AspNetCore.Identity;
using RestaurantProject.Application.Abstractions.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
	public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
	{
		// Default Data
		builder.HasData(new IdentityUserRole<string>
		{
			UserId = DefaultUsers.Admin.Id,
			RoleId = DefaultRoles.Admin.Id
		});
	}
}