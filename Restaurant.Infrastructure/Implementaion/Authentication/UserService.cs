using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Math.EC.Rfc7748;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.User;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IAuthentication;

namespace RestaurantProject.Infrastructure.Implementaion.Authentication;
public class UserService(UserManager<ApplicationUser> userManager,
	IRoleService roleService) : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly IRoleService _roleService = roleService;

	public async Task<Result<UserResponse>> CreateAsync(CreateUserRequest request, CancellationToken cancellationToken = default)
	{
		var emailIsExist = await _userManager.Users.AnyAsync(x=>x.Email==request.Email,cancellationToken);

		if (emailIsExist)
			return Result.Failure<UserResponse>(UserErrors.DuplicatedEmail);

		var allowRoles=await _roleService.GetAllAsync(cancellationToken: cancellationToken);

	    if (request.Roles.Except(allowRoles.Select(x=>x.Name)).Any())
			return Result.Failure<UserResponse>(UserErrors.InvalidRoles);

		var user=request.Adapt<ApplicationUser>();
		var result = await _userManager.CreateAsync(user, request.Password);

		if(result.Succeeded)
		{
		    await _userManager.AddToRolesAsync(user, request.Roles);
			var response =(user,request.Roles).Adapt<UserResponse>();
			return Result.Success(response);
		}
		else
		{
			var error = result.Errors.First();
			return Result.Failure<UserResponse>(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest)); 
		}


	}
}
