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
	}
}
