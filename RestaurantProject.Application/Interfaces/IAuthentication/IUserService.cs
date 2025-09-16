using RestaurantProject.Application.Contracts.User;

namespace RestaurantProject.Application.Interfaces.IAuthentication;
public interface IUserService
{
	Task<Result<UserResponse>> GetAsync(string userId);
	Task<Result<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default);
	Task<Result> UpdateAsync(string userId, UpdateUserRequest request, CancellationToken cancellationToken = default);
	Task<Result> ToggleStatusAsync(string id);
	Task<Result> UnlockAsync(string id);
	Task<Result<UserProfileResponse>> GetProfileInfoAsync(string userId);
}
