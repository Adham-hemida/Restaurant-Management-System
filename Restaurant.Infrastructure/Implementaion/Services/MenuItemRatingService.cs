using Azure.Core;
using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using System.Linq.Dynamic.Core;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class MenuItemRatingService(IMenuItemRatingRepository menuItemRatingRepository,
	IOrderRepository orderRepository,
	IMenuItemRepository menuItemRepository) : IMenuItemRatingService

{
	private readonly IMenuItemRatingRepository _menuItemRatingRepository = menuItemRatingRepository;
	private readonly IOrderRepository _orderRepository = orderRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

	public async Task<Result<MenuItemRatingResponse>> GetAsync(int orderId, int menuItemId, int menuItemRatingId, CancellationToken cancellationToken)
	{
		var orderIsExist = await _orderRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == orderId && x.IsActive, cancellationToken);
	
		if (!orderIsExist)
			return Result.Failure<MenuItemRatingResponse>(OrderErrors.OrderNotFound);
		
		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuItemId && x.IsActive, cancellationToken);
		
		if (!menuItemIsExist)
			return Result.Failure<MenuItemRatingResponse>(MenuItemErrors.MenuItemNotFound);
	
		var menuItemRating = await _menuItemRatingRepository.GetAsQueryable()
			.Where(x => x.Id == menuItemRatingId && x.OrderId == orderId && x.MenuItemId == menuItemId && x.IsActive)
			.AsNoTracking()
			.ProjectToType<MenuItemRatingResponse>()
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItemRating is null)
			return Result.Failure<MenuItemRatingResponse>(MenuItemRatingErrors.MenuItemRatingNotFound);

		return Result.Success(menuItemRating);
	}

	public async Task<Result<PaginatedList<MenuItemRatingResponse>>>GetAllAsync(int menuItemId, RequestFilters filters, CancellationToken cancellationToken)
	{
		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuItemId && x.IsActive, cancellationToken);

		if (!menuItemIsExist)
			return Result.Failure<PaginatedList<MenuItemRatingResponse>>(MenuItemErrors.MenuItemNotFound);

		var query = _menuItemRatingRepository.GetAsQueryable()
			.Where(x=>x.MenuItemId==menuItemId && x.IsActive );

		if (!string.IsNullOrEmpty(filters.SearchValue))
		{
			query = query.Where(x => x.Rating.ToString().Contains(filters.SearchValue));
		}
		if (!string.IsNullOrEmpty(filters.SortColumn))
		{
			query = query.OrderBy($"{filters.SortColumn} {filters.SortDirection}");
		}

		var source = query.AsNoTracking()
			.ProjectToType<MenuItemRatingResponse>();

		var menuItemsRating = await PaginatedList<MenuItemRatingResponse>.CreateAsync(source, filters.PageNumber, filters.PageSize, cancellationToken);

		return Result.Success(menuItemsRating);

	}
	public async Task<Result<MenuItemRatingResponse>> AddAsync(int orderId,int menuItemId, MenuItemRatingRequest request,CancellationToken cancellationToken)
	{
		var orderIsExist = await _orderRepository.GetAsQueryable()
	         .AnyAsync(x => x.Id == orderId && x.IsActive, cancellationToken);

		if (!orderIsExist)
			return Result.Failure<MenuItemRatingResponse>(OrderErrors.OrderNotFound);

		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuItemId && x.IsActive, cancellationToken);

		if (!menuItemIsExist)
			return Result.Failure<MenuItemRatingResponse>(MenuItemErrors.MenuItemNotFound);

		var menuItemRating = request.Adapt<MenuItemRating>();
		menuItemRating.MenuItemId = menuItemId;
		menuItemRating.OrderId = orderId;

		await _menuItemRatingRepository.AddAsync(menuItemRating, cancellationToken);

		return Result.Success(menuItemRating.Adapt<MenuItemRatingResponse>());
	}

	public async Task<Result> ToggleStatusAsync(int orderId, int menuItemId, int menuItemRatingId, CancellationToken cancellationToken)
	{
		var orderIsExist = await _orderRepository.GetAsQueryable()
			 .AnyAsync(x => x.Id == orderId && x.IsActive, cancellationToken);

		if (!orderIsExist)
			return Result.Failure<MenuItemRatingResponse>(OrderErrors.OrderNotFound);

		var menuItemIsExist = await _menuItemRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == menuItemId && x.IsActive, cancellationToken);

		if (!menuItemIsExist)
			return Result.Failure<MenuItemRatingResponse>(MenuItemErrors.MenuItemNotFound);

		var menuItemRating = await _menuItemRatingRepository.GetAsQueryable()
			.Where(x => x.Id == menuItemRatingId && x.OrderId == orderId && x.MenuItemId == menuItemId)
			.SingleOrDefaultAsync(cancellationToken);

		if (menuItemRating is null)
			return Result.Failure(MenuItemRatingErrors.MenuItemRatingNotFound);

		menuItemRating.IsActive = !menuItemRating.IsActive;
		await _menuItemRatingRepository.UpdateAsync(menuItemRating,cancellationToken);
		return Result.Success();

	}
}
