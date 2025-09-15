using RestaurantProject.Application.Features.Role.Commands.Models;

namespace RestaurantProject.Application.Features.Role.Commands.Handlers;
public class AddRoleCommandsHandler( IRoleService roleService) : IRequestHandler<AddRoleCommands, Result<RoleDetailResponse>>
{
	private readonly IRoleService _roleService = roleService;

	public async Task<Result<RoleDetailResponse>> Handle(AddRoleCommands request, CancellationToken cancellationToken)
	{
		return await _roleService.AddAsync(request.RoleRequest);
	}
}
