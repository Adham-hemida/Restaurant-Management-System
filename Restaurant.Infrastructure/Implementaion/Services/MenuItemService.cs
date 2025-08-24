using Mapster;
using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class MenuItemService(IMenuCategoryRepository menuCategoryRepository,
	IMenuItemRepository menuItemRepository,
	IHttpContextAccessor httpContextAccessor) : IMenuItemService
{
	private readonly IMenuCategoryRepository _menuCategoryRepository = menuCategoryRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;
	private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

	public async Task<Result<MenuItemResponse>> GetAsync(int menuCategoryId,int menuItemId,CancellationToken cancellationToken)
	{
		var menuCategoryIsExist=await _menuCategoryRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure<MenuItemResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		var menuItem = await _menuItemRepository.GetAsQueryable()
			.Where( x => x.Id == menuItemId && x.IsActive)
			.AsNoTracking()
			.ProjectToType<MenuItemResponse>()
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem is null)
			return Result.Failure<MenuItemResponse>(MenuItemErrors.MenuItemNotFound);

		return Result.Success(menuItem);
	}
	
	public async Task<Result<MenuItemWithImagesResponse>> GetMenuItemWithImagesAsync(int menuCategoryId,int menuItemId,CancellationToken cancellationToken)
	{
		var menuCategoryIsExist=await _menuCategoryRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure<MenuItemWithImagesResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		var httpRequest = _httpContextAccessor.HttpContext?.Request;
		var origin = $"{httpRequest?.Scheme}://{httpRequest?.Host}";


		var menuItem = await _menuItemRepository.GetAsQueryable()
			.Where( x => x.Id == menuItemId && x.IsActive)
			.Include(x => x.UploadedFiles)
			.Select(m=>new MenuItemWithImagesResponse
			(m.Id,
			m.Name,
			m.Description,
			m.Price,
			m.UploadedFiles.Select(i=> new UploadedFileResponse(
				i.Id,
				i.FileName,
				$"{origin}/images/{i.FileName}"
				)).ToList()
			))
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem is null)
			return Result.Failure<MenuItemWithImagesResponse>(MenuItemErrors.MenuItemNotFound);

		return Result.Success(menuItem);
	}
}
