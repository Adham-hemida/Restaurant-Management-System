using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MenuCategoriesController(IMenuCategoryService menuCategoryService) : ControllerBase
{
	private readonly IMenuCategoryService _menuCategoryService = menuCategoryService;
	[HttpPost("")]
	public async Task<IActionResult> Create([FromBody] MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var result = await _menuCategoryService.CreateAsync(request, cancellationToken);

		return result.IsSuccess
			? Ok(result.Value)
			: result.ToProblem();


	}

}
