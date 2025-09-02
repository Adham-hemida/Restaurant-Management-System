using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuItemRating;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class MenuItemRatingService(IMenuItemRatingRepository menuItemRatingRepository,
	IOrderRepository orderRepository,
	IMenuItemRepository menuItemRepository) : IMenuItemRatingService

{
	private readonly IMenuItemRatingRepository _menuItemRatingRepository = menuItemRatingRepository;
	private readonly IOrderRepository _orderRepository = orderRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

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
}
