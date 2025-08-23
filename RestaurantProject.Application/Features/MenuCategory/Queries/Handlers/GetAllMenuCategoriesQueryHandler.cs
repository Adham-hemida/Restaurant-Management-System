namespace RestaurantProject.Application.Features.MenuCategory.Queries.Handlers;
public class GetAllMenuCategoriesQueryHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<GetAllMenuCategoriesQuery, IEnumerable<MenuCategoryResponse1>>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<IEnumerable<MenuCategoryResponse1>> Handle(GetAllMenuCategoriesQuery request, CancellationToken cancellationToken)
	{
		return await _menuCategoryService.GetAllAsync(cancellationToken);
	}
}

