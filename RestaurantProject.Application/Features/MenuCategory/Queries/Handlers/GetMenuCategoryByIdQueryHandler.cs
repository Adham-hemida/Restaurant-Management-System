namespace RestaurantProject.Application.Features.MenuCategory.Queries.Handlers;
public class GetMenuCategoryByIdQueryHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<GetMenuCategoryWithMenuItemsQuery, Result<MenuCategoryWithMenuItemsResponse>>
{
	private readonly IMenuCategoryService _menuCategoryService= menuCategoryService;
	
	public async Task<Result<MenuCategoryWithMenuItemsResponse>> Handle(GetMenuCategoryWithMenuItemsQuery request, CancellationToken cancellationToken)
	{
		return await _menuCategoryService.GetMenuCategoryWithMenuItemsAsync(request.Id, cancellationToken);
	}
}
