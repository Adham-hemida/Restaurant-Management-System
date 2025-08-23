namespace RestaurantProject.Application.Features.MenuCategory.Command.Handlers;
public class UpdateMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<UpdateMenuCategoryCommand, Result<MenuCategoryResponse>>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<Result<MenuCategoryResponse>> Handle(UpdateMenuCategoryCommand request, CancellationToken cancellationToken)
	{
      return await _menuCategoryService.UpdateAsync(request.Id, request.MenuCategoryRequest, cancellationToken);
	}
}

