namespace RestaurantProject.Application.Features.MenuCategory.Command.Models;

public record AddMenuCategoryCommand(MenuCategoryRequest MenuCategoryRequest) : IRequest<Result<MenuCategoryResponse>>;