namespace RestaurantProject.Application.Features.Role.Commands.Models;
public record UpdateRoleCommand(string Id, RoleRequest RoleRequest) : IRequest<Result>;
