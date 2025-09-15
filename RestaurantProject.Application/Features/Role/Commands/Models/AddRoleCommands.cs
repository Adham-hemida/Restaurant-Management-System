namespace RestaurantProject.Application.Features.Role.Commands.Models;
public record AddRoleCommands(RoleRequest RoleRequest) : IRequest<Result<RoleDetailResponse>>;
