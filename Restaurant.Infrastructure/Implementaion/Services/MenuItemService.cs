using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Hybrid;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using System.Linq.Dynamic.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

	public async Task<Result<PaginatedList<MenuItemWithImagesResponse>>> GetAllAsync(int menuCategoryId, RequestFilters filters, CancellationToken cancellationToken)
	{
		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure<PaginatedList<MenuItemWithImagesResponse>>(MenuCategoryErrors.MenuCategoryNotFound);

		var query =  _menuItemRepository.GetAsQueryable()
			.Where(x => x.CategoryId == menuCategoryId && x.IsActive);

		if (!string.IsNullOrEmpty(filters.SearchValue))
		{
			query = query.Where(x => x.Name.Contains(filters.SearchValue));
		}
		if (!string.IsNullOrEmpty(filters.SortColumn))
		{
			query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
		}

		var httpRequest = _httpContextAccessor.HttpContext?.Request;
		var origin = $"{httpRequest?.Scheme}://{httpRequest?.Host}";


		var source = query.AsNoTracking()
			.Include(x => x.UploadedFiles)
			.Select(x=>new MenuItemWithImagesResponse(
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

				));
		var menuItems = await PaginatedList<MenuItemWithImagesResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);

		return Result.Success(menuItems);
	}

    public async Task<Result<MenuItemResponse>> AddAsync(int menuCategoryId, MenuItemRequest request,CancellationToken cancellationToken)
	{
		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure<MenuItemResponse>(MenuCategoryErrors.MenuCategoryNotFound);

		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Name.ToUpper() == request.Name.ToUpper() && x.CategoryId==menuCategoryId, cancellationToken);

		if (menuItemIsExist)
			return Result.Failure<MenuItemResponse>(MenuItemErrors.DuplicatedMenuItem);

		var menuItem = request.Adapt<MenuItem>();
		menuItem.CategoryId = menuCategoryId;
		await _menuItemRepository.AddAsync(menuItem, cancellationToken);
		return Result.Success(menuItem.Adapt<MenuItemResponse>());
	}

	public async Task<Result> UpdateAsync(int menuCategoryId, int menuItemId, MenuItemRequest request, CancellationToken cancellationToken)
	{
		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable()
	          .AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure(MenuCategoryErrors.MenuCategoryNotFound);

		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Name.ToUpper() == request.Name.ToUpper() && x.CategoryId == menuCategoryId && x.Id !=menuItemId, cancellationToken);

		if (menuItemIsExist)
			return Result.Failure(MenuItemErrors.DuplicatedMenuItem);

		var menuItem = await _menuItemRepository.GetAsQueryable()
			.Where(x => x.Id == menuItemId && x.CategoryId==menuCategoryId && x.IsActive)
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem is null)
			return Result.Failure(MenuItemErrors.MenuItemNotFound);

		menuItem= request.Adapt(menuItem);
		await _menuItemRepository.UpdateAsync(menuItem, cancellationToken);
		return Result.Success();
	}

	public async Task<Result> ChangePriceAsync(int menuCategoryId, int menuItemId, ChangePriceRequest request, CancellationToken cancellationToken)
	{
		var menuCategoryIsExist = await _menuCategoryRepository.GetAsQueryable()
	       .AnyAsync(x => x.Id == menuCategoryId && x.IsActive, cancellationToken);

		if (!menuCategoryIsExist)
			return Result.Failure(MenuCategoryErrors.MenuCategoryNotFound);

		var menuItem = await _menuItemRepository.GetAsQueryable()
			.Where(x => x.Id == menuItemId && x.CategoryId == menuCategoryId && x.IsActive)
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem is null)
			return Result.Failure(MenuItemErrors.MenuItemNotFound);

		menuItem.Price = request.Price;
		await _menuItemRepository.UpdateAsync(menuItem, cancellationToken);
		return Result.Success();
	}


	public async Task<Result> ToggleSatausAsync(int menuCategoryId, int menuItemId, CancellationToken cancellationToken = default)
	{
		var menuItem = await _menuItemRepository.GetAsQueryable()
			.Where(x => x.Id == menuItemId && x.CategoryId == menuCategoryId)
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItem is null)
			return Result.Failure(MenuItemErrors.MenuItemNotFound);

		menuItem.IsActive = !menuItem.IsActive;
		await _menuItemRepository.UpdateAsync(menuItem, cancellationToken);

		return Result.Success();
	}


}
