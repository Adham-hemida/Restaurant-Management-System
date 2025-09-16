using Mapster;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Application.Mapping;
public class MappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<CreateUserRequest, ApplicationUser>()
			 .Map(dest => dest.UserName, src => src.Email)
			 .Map(dest => dest.EmailConfirmed, src => true);

		config.NewConfig<(ApplicationUser user, IList<string> roles), UserResponse>()
			.Map(dest => dest, src => src.user)
			.Map(dest => dest.Roles, src => src.roles);
	}
}
