namespace RestaurantProject.Application.Features.MenuCategory.Queries.Handlers;
public class GetMenuCategoryByIdQueryHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<GetMenuCategoryByIdQuery, Result<MenuCategoryResponse>>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<Result<MenuCategoryResponse>> Handle(GetMenuCategoryByIdQuery request, CancellationToken cancellationToken)
	{
		return  await _menuCategoryService.GetAsync(request.Id,cancellationToken);
	
	}
}

