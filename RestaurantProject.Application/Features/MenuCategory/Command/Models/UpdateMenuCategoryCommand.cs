namespace RestaurantProject.Application.Features.MenuCategory.Command.Models;
public record UpdateMenuCategoryCommand(int Id,MenuCategoryRequest MenuCategoryRequest) : IRequest<Result<MenuCategoryResponse>>;
