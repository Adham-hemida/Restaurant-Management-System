using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;

namespace RestaurantProject.Application.ErrorHandler;
public static class MenuCategoryErrors
{
	public static readonly Error MenuCategoryNotFound =
	new("MenuCategory.not_found", "No MenuCategory was found with the given Id", StatusCodes.Status404NotFound);
	
	public static readonly Error MenuCategoryNotActive =
	new("MenuCategory.not_Active", "MenuCategory was not Active with the given Id", StatusCodes.Status404NotFound);

	public static readonly Error DuplicatedMenuCategory =
		new("MenuCategory.Duplicated", " Another MenuCategory is already exist", StatusCodes.Status409Conflict);
}