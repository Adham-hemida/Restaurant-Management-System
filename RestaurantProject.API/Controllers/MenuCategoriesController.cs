using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Features.MenuCategory.Command.Models;
using RestaurantProject.Application.Features.MenuCategory.Queries.Models;
using RestaurantProject.Application.Interfaces.IService;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MenuCategoriesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuCategoryByIdQuery(id),cancellationToken);

		return result.IsSuccess? Ok(result.Value): result.ToProblem();
	}

	[HttpGet("")]
	public async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
	{	
		return Ok(await _mediator.Send(new GetAllMenuCategoriesQuery(), cancellationToken));
	}

	[HttpPost("")]
	public async Task<IActionResult> Create([FromBody] MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddMenuCategoryCommand(request),cancellationToken);

		return result.IsSuccess? CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value) : result.ToProblem();
	}

}
