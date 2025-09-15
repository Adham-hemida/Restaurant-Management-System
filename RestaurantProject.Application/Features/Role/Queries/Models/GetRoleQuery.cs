namespace RestaurantProject.Application.Features.Role.Queries.Models;
public record GetRoleQuery (string RoleId) : IRequest<Result<RoleDetailResponse>>;
