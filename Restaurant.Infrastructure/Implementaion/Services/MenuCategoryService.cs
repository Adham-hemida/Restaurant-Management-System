using Mapster;
using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class MenuCategoryService(IMenuCategoryRepository menuCategoryRepository, IHttpContextAccessor httpContextAccessor) : IMenuCategoryService
{
	private readonly IMenuCategoryRepository _menuCategoryRepository = menuCategoryRepository;
	private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

	public async Task<Result<MenuCategoryResponse>> GetAsync (int id, CancellationToken cancellationToken)
	{
		var menuCategory = await _menuCategoryRepository.GetByIdAsync(id, cancellationToken);

		if (menuCategory is null)
			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		var response = new MenuCategoryResponse
		(
			menuCategory.Id,
			menuCategory.Name,
			menuCategory.Description,
			menuCategory.MenuItems.Select(x => new MenuItemResponse(
				x.Id,
				x.Name,
				x.Description,
				x.Price,
				x.UploadedFiles.Select(i => new UploadedFileResponse
				(
					i.Id,
					i.FileName,
					$"{_httpContextAccessor.HttpContext?.Request.Scheme}://{_httpContextAccessor.HttpContext?.Request.Host}/uploads/{i.FileName}"
				)).ToList()
			)).ToList()
		);
		return Result.Success(response);

	}
	public  async Task<IEnumerable<MenuCategoryResponse1>> GetAllAsync( CancellationToken cancellationToken)
	{
		return await  _menuCategoryRepository
			.GetAsQueryable()
			.Where(x => x.IsActive)
			.AsNoTracking()
			.ProjectToType<MenuCategoryResponse1>()
			.ToListAsync(cancellationToken);

	}
	public async Task<Result<MenuCategoryResponse>> CreateAsync(MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var httpRequest = _httpContextAccessor.HttpContext?.Request;
		var origin = $"{httpRequest?.Scheme}://{httpRequest?.Host}";

		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable().AnyAsync(x => x.Name.ToUpper() == request.Name.ToUpper().Trim(), cancellationToken);

		if (menuCategoryIsExist)
			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.DuplicatedMenuCategory);

		var menuCategory = request.Adapt<MenuCategory>();
		await _menuCategoryRepository.AddAsync(menuCategory, cancellationToken);
		var response = new MenuCategoryResponse
			(
				menuCategory.Id,
				menuCategory.Name,
				menuCategory.Description,
				menuCategory.MenuItems.Select(x => new MenuItemResponse(
					x.Id,
					x.Name,
					x.Description,
					x.Price,
					x.UploadedFiles.Select(i => new UploadedFileResponse
					(
						i.Id,
						i.FileName,
						 $"{origin}/uploads/{i.FileName}"
					)).ToList()
				)).ToList()
			); 
		
		return Result.Success(response);
	}
}
