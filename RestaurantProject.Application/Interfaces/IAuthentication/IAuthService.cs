using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantProject.Application.Interfaces.IAuthentication;
public interface IAuthService
{
	Task<Result<AuthResponse>> GetTokenAsync(LoginRequest loginRequest, CancellationToken cancellationToken = default);
	Task<Result<AuthResponse>> GetRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest, CancellationToken cancellationToken = default);
	Task<Result> RevokeRefreshTokenAsync(RefreshTokenRequest refreshTokenRequest, CancellationToken cancellationToken = default);
	Task<Result> SendResetPasswordCodeAsync(string email);
	Task<Result> ResetPasswordAsync(ResetPasswordRequest request);

}
