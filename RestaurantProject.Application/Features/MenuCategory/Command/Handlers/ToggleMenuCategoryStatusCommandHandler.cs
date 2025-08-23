namespace RestaurantProject.Application.Features.MenuCategory.Command.Handlers;
public class ToggleMenuCategoryStatusCommandHandler(IMenuCategoryService menuCategoryService) : IRequestHandler<ToggleMenuCategoryStatusCommand, Result>
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;

	public async Task<Result> Handle(ToggleMenuCategoryStatusCommand request, CancellationToken cancellationToken)
	{
		return await _menuCategoryService.ToggleSatausAsync(request.Id, cancellationToken);
	}
}
