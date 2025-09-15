namespace RestaurantProject.Application.Features.Role.Queries.Handlers;
public class GetAllRolesQueryHandler (IRoleService roleService) : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleResponse>>
{
	private readonly IRoleService _roleService = roleService;
	public async Task<IEnumerable<RoleResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
	{
		return await _roleService.GetAllAsync(request.IncludeDisabled, cancellationToken);
	}

}
