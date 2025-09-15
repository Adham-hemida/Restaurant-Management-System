using RestaurantProject.Application.Features.Role.Commands.Models;

namespace RestaurantProject.Application.Features.Role.Commands.Handlers;
public class RoleToggleSatausCommandHandler(IRoleService roleService) : IRequestHandler<RoleToggleSatausCommand, Result>
{
	private readonly IRoleService _roleService = roleService;

	public async Task<Result> Handle(RoleToggleSatausCommand request, CancellationToken cancellationToken)
	{
		return await _roleService.ToggleStatusAsync(request.Id);
	}
}
