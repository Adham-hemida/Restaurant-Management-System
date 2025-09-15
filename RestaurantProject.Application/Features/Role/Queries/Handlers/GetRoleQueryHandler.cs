namespace RestaurantProject.Application.Features.Role.Queries.Handlers;
public class GetRoleQueryHandler(IRoleService roleService) : IRequestHandler<GetRoleQuery, Result<RoleDetailResponse>>
{
	private readonly IRoleService _roleService = roleService;
	public async Task<Result<RoleDetailResponse>> Handle(GetRoleQuery request, CancellationToken cancellationToken)
	{
		return await _roleService.GetAsync(request.RoleId);
	}

}
