namespace RestaurantProject.Application.Features.Role.Queries.Models;
public record GetAllRolesQuery (bool IncludeDisabled = false) : IRequest<IEnumerable<RoleResponse>>;
