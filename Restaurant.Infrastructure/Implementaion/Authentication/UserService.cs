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
	IRoleRepository roleRepository,
	IRoleService roleService) : IUserService
{
	private readonly UserManager<ApplicationUser> _userManager = userManager;
	private readonly IRoleRepository _roleRepository = roleRepository;
	private readonly IRoleService _roleService = roleService;

	public async Task<Result<UserResponse>> GetAsync(string userId)
	{
		if(await _userManager.FindByIdAsync(userId) is not { } user)
			return Result.Failure<UserResponse>(UserErrors.UserNotFound);

		var roles = await _userManager.GetRolesAsync(user);
		var response = (user, roles).Adapt<UserResponse>();
		return Result.Success(response);
	}

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

	public async Task<Result> UpdateAsync(string userId, UpdateUserRequest request, CancellationToken cancellationToken = default)
	{
		if (await _userManager.FindByIdAsync(userId) is not { } user)
			return Result.Failure(UserErrors.UserNotFound);

		var emailIsExist = await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != userId, cancellationToken);

		if (emailIsExist)
			return Result.Failure(UserErrors.DuplicatedEmail);

		var allowRoles = await _roleService.GetAllAsync(cancellationToken: cancellationToken);

		if (request.Roles.Except(allowRoles.Select(x => x.Name)).Any())
			return Result.Failure(UserErrors.InvalidRoles);

		user= request.Adapt(user);
		var result = await _userManager.UpdateAsync(user);
		if (result.Succeeded)
		{
			await _roleRepository.DeleteRolesOfUserAsync(user.Id, cancellationToken);
			await _userManager.AddToRolesAsync(user, request.Roles);
			return Result.Success();
		}
		else
		{
			var error = result.Errors.First();
			return Result.Failure(new Error(error.Code, error.Description, StatusCodes.Status400BadRequest));
		}



	}
}
