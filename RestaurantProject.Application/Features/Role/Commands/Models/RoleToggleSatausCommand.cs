namespace RestaurantProject.Application.Features.Role.Commands.Models;
public record RoleToggleSatausCommand (string Id) : IRequest<Result>;
