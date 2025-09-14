using RestaurantProject.Application.Abstractions.Consts;

namespace RestaurantProject.Infrastructure.EntitesConfigurations;
public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
	public void Configure(EntityTypeBuilder<ApplicationRole> builder)
	{
		// Default Data
		builder.HasData([
			new ApplicationRole{
				Id = DefaultRoles.Admin.Id,
				Name = DefaultRoles.Admin.Name,
				NormalizedName = DefaultRoles.Admin.Name.ToUpper(),
				ConcurrencyStamp = DefaultRoles.Admin.ConcurrencyStamp,
			},
			new ApplicationRole{
				Id = DefaultRoles.Manager.Id,
				Name = DefaultRoles.Manager.Name,
				NormalizedName = DefaultRoles.Manager.Name.ToUpper(),
				ConcurrencyStamp = DefaultRoles.Manager.ConcurrencyStamp,
			},
				new ApplicationRole{
				Id = DefaultRoles.Chef.Id,
				Name = DefaultRoles.Chef.Name,
				NormalizedName = DefaultRoles.Chef.Name.ToUpper(),
				ConcurrencyStamp = DefaultRoles.Chef.ConcurrencyStamp,
			},
				new ApplicationRole{
				Id = DefaultRoles.Waiter.Id,
				Name = DefaultRoles.Waiter.Name,
				NormalizedName = DefaultRoles.Waiter.Name.ToUpper(),
				ConcurrencyStamp = DefaultRoles.Waiter.ConcurrencyStamp,
			},
				new ApplicationRole{
				Id = DefaultRoles.Cashier.Id,
				Name = DefaultRoles.Cashier.Name,
				NormalizedName = DefaultRoles.Cashier.Name.ToUpper(),
				ConcurrencyStamp = DefaultRoles.Cashier.ConcurrencyStamp,
			},
				new ApplicationRole{
				Id = DefaultRoles.Staff.Id,
				Name = DefaultRoles.Staff.Name,
				NormalizedName = DefaultRoles.Staff.Name.ToUpper(),
				ConcurrencyStamp = DefaultRoles.Staff.ConcurrencyStamp,
			}


			]);
	}
}