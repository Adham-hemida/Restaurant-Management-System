namespace RestaurantProject.Application.Features.MenuCategory.Queries.Handlers;
public class GetAllMenuCategoriesQueryHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<GetAllMenuCategoriesQuery, IEnumerable<MenuCategoryBasicResponse>>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<IEnumerable<MenuCategoryBasicResponse>> Handle(GetAllMenuCategoriesQuery request, CancellationToken cancellationToken)
	{
		return await _menuCategoryService.GetAllAsync(cancellationToken);
	}
}

