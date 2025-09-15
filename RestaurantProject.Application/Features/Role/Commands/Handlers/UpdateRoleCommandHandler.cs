using RestaurantProject.Application.Features.Role.Commands.Models;

namespace RestaurantProject.Application.Features.Role.Commands.Handlers;
public class UpdateRoleCommandHandler(IRoleService roleService) : IRequestHandler<UpdateRoleCommand, Result>
{
	private readonly IRoleService _roleService = roleService;

	public async Task<Result> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
	{
		return await _roleService.UpdateAsync(request.Id, request.RoleRequest);
	}
}
