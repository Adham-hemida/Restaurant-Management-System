using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.ErrorHandler;
public static class MenuItemErrors
{
	public static readonly Error MenuItemNotFound =
	new("MenuItem.not_found", "No MenuItem was found with the given Id", StatusCodes.Status404NotFound);


	public static readonly Error DuplicatedMenuItem =
		new("MenuItem.Duplicated", " Another MenuItem is already exist", StatusCodes.Status409Conflict);
}
