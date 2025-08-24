using Mapster;
using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using System.Linq.Dynamic.Core;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class MenuCategoryService(IMenuCategoryRepository menuCategoryRepository, IHttpContextAccessor httpContextAccessor) : IMenuCategoryService
{
	private readonly IMenuCategoryRepository _menuCategoryRepository = menuCategoryRepository;
	private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

	public async Task<Result<MenuCategoryResponse>> GetAsync(int id, CancellationToken cancellationToken)
	{
		var menuCategory = await _menuCategoryRepository.GetByIdAsync(id, cancellationToken);

		if (menuCategory is null)
			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		return Result.Success(menuCategory.Adapt<MenuCategoryResponse>());

	}


	public async Task<Result<MenuCategoryWithMenuItemsResponse>> GetMenuCategoryWithMenuItemsAsync(int id, CancellationToken cancellationToken)
	{
		var httpRequest = _httpContextAccessor.HttpContext?.Request;
		var origin = $"{httpRequest?.Scheme}://{httpRequest?.Host}";

		var menuCategory = await _menuCategoryRepository.GetAsQueryable()
			.Where(x=>x.Id==id && x.IsActive)
			.Include(x => x.MenuItems)
			   .ThenInclude(x => x.UploadedFiles)
			.Select(m => new MenuCategoryWithMenuItemsResponse
		(
			m.Id,
			m.Name,
			m.Description,
			m.MenuItems.Where(x=>x.IsActive).Select(x => new MenuItemWithImagesResponse(
				x.Id,
				x.Name,
				x.Description,
				x.Price,
				x.UploadedFiles.Select(i => new UploadedFileResponse
				(
					i.Id,
					i.FileName,
					$"{origin}/images/{i.FileName}"
				)).ToList()
			)).ToList()
		)).SingleOrDefaultAsync(cancellationToken);

		if (menuCategory is null)
			return Result.Failure<MenuCategoryWithMenuItemsResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		return Result.Success(menuCategory);
	}
	public async Task<Result<PaginatedList<MenuCategoryResponse>>> GetAllAsync(RequestFilters filters,CancellationToken cancellationToken)
	{
		var query =_menuCategoryRepository.GetAsQueryable()
			.Where(x => x.IsActive);

		if (!string.IsNullOrEmpty(filters.SearchValue))
		{
			query = query.Where(x => x.Name.Contains(filters.SearchValue) );
		}

		if (!string.IsNullOrEmpty(filters.SortColumn))
		{
			query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
		}
			
		var source=query.AsNoTracking()
			.ProjectToType<MenuCategoryResponse>();

		var students = await PaginatedList<MenuCategoryResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);

		return Result.Success(students);
	}

	public async Task<Result<MenuCategoryResponse>> CreateAsync(MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable().AnyAsync(x => x.Name.ToUpper().Trim() == request.Name.ToUpper().Trim(), cancellationToken);

		if (menuCategoryIsExist)
			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.DuplicatedMenuCategory);

		var menuCategory = request.Adapt<MenuCategory>();
		await _menuCategoryRepository.AddAsync(menuCategory, cancellationToken);

		return Result.Success(menuCategory.Adapt<MenuCategoryResponse>());
	}


	public async Task<Result<MenuCategoryResponse>> UpdateAsync(int id, MenuCategoryRequest request, CancellationToken cancellationToken)
	{

		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable()
		 .AnyAsync(x => x.Name.ToUpper().Trim() == request.Name.ToUpper().Trim() && x.Id != id, cancellationToken);

		if (menuCategoryIsExist)
			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.DuplicatedMenuCategory);


		var menuCategory = await _menuCategoryRepository.GetByIdAsync(id, cancellationToken);

		if (menuCategory is null)
			return Result.Failure<MenuCategoryResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		menuCategory = request.Adapt(menuCategory);
		await _menuCategoryRepository.UpdateAsync(menuCategory, cancellationToken);


		return Result.Success(menuCategory.Adapt<MenuCategoryResponse>());
	}


	public async Task<Result> ToggleSatausAsync(int id, CancellationToken cancellationToken)
	{
		var menuCategory = await _menuCategoryRepository.GetByIdAsync(id, cancellationToken);

		if (menuCategory is null)
			return Result.Failure(MenuCategoryErrors.MenuCategoryNotFound);

		menuCategory.IsActive = !menuCategory.IsActive;
		await _menuCategoryRepository.UpdateAsync(menuCategory, cancellationToken);
		return Result.Success();
	}


}
