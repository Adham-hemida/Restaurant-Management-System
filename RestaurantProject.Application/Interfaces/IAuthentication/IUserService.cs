using RestaurantProject.Application.Contracts.User;

namespace RestaurantProject.Application.Interfaces.IAuthentication;
public interface IUserService
{
	Task<Result<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
}
