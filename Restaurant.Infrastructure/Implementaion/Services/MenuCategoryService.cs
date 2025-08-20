//using Mapster;
//using RestaurantProject.Application.Abstractions;
//using RestaurantProject.Application.Contracts.MenuCategory;
//using RestaurantProject.Application.ErrorHandler;
//using RestaurantProject.Application.Interfaces.IService;

//namespace RestaurantProject.Infrastructure.Implementaion.Services;
//public class MenuCategoryService(IMenuCategoryRepository menuCategoryRepository) : IMenuCategoryService
//{
//	private readonly IMenuCategoryRepository _menuCategoryRepository = menuCategoryRepository;

//	public async Task<Result<MenuCategoryResponse>>CreateAsync(MenuCategoryRequest request,CancellationToken cancellationToken)
//	{
//		var menuCategoryIsExist =await _menuCategoryRepository.GetAsQueryable().AnyAsync(x=>x.Name.ToUpper() == request.Name.ToUpper().Trim(), cancellationToken);

//		if (menuCategoryIsExist)
//			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.DuplicatedMenuCategory);

//		var menuCategory = request.Adapt<MenuCategory>();
//		await _menuCategoryRepository.AddAsync(menuCategory, cancellationToken);
//		return Result.Success(menuCategory.Adapt<MenuCategoryResponse>());

//	}
//}
