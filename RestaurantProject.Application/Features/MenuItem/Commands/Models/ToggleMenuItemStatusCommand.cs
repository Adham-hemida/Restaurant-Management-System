namespace RestaurantProject.Application.Features.MenuItem.Commands.Models;
public record ToggleMenuItemStatusCommand(int MenuCategoryId,int MenuItemId) : IRequest<Result>;
