namespace RestaurantProject.Application.Features.MenuCategory.Command.Models;
public record ToggleMenuCategoryStatusCommand(int Id) : IRequest<Result>;

