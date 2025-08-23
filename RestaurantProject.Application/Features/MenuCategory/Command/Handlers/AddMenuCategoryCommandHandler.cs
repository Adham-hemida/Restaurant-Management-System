using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Application.Features.MenuCategory.Command.Handlers;

public class AddMenuCategoryCommandHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<AddMenuCategoryCommand, Result<MenuCategoryResponse>>
{
	private readonly IMenuCategoryService _menuCategoryService= menuCategoryService;
	
	public async Task<Result<MenuCategoryResponse>> Handle(AddMenuCategoryCommand request, CancellationToken cancellationToken)
	{
		return await _menuCategoryService.CreateAsync(request.MenuCategoryRequest,cancellationToken);
	}
}

