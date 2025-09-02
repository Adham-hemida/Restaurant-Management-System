using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;

public static class MenuItemRatingErrors
{
	public static readonly Error MenuItemRatingNotFound =
	new("MenuItemRating.not_found", "No MenuItemRating was found with the given Id", StatusCodes.Status404NotFound);
}
