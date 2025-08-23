namespace RestaurantProject.Application.Features.MenuCategory.Command.Handlers;
public class UpdateMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<UpdateMenuCategoryCommand, Result<MenuCategoryBasicResponse>>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<Result<MenuCategoryBasicResponse>> Handle(UpdateMenuCategoryCommand request, CancellationToken cancellationToken)
	{
      return await _menuCategoryService.UpdateAsync(request.Id, request.MenuCategoryRequest, cancellationToken);
	}
}

