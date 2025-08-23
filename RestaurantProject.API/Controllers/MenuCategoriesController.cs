using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Features.MenuCategory.Command.Models;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MenuCategoriesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost("")]
	public async Task<IActionResult> Create([FromBody] MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddMenuCategoryCommand(request),cancellationToken);

		return result.IsSuccess? Ok(result.Value): result.ToProblem();
	}

}
