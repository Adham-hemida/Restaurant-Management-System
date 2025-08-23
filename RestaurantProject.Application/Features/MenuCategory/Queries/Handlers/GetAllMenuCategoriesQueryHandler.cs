namespace RestaurantProject.Application.Features.MenuCategory.Queries.Handlers;
public class GetAllMenuCategoriesQueryHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<GetAllMenuCategoriesQuery, Result<PaginatedList<MenuCategoryResponse>>>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<Result<PaginatedList<MenuCategoryResponse>>> Handle(GetAllMenuCategoriesQuery request, CancellationToken cancellationToken)
	{
		return await _menuCategoryService.GetAllAsync(request.Filters, cancellationToken);
	}
}

