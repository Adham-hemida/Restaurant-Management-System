using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuCategory;
using RestaurantProject.Application.Features.MenuCategory.Command.Models;
using RestaurantProject.Application.Features.MenuCategory.Queries.Models;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MenuCategoriesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	[HasPermission(Permissions.GetMenuCategories)]
	public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuCategoryByIdQuery(id), cancellationToken);

		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("{id}/WithItems")]
	[HasPermission(Permissions.GetMenuCategories)]
	public async Task<IActionResult> GetMenuCategoryWithMenuItems([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuCategoryWithMenuItemsQuery(id),cancellationToken);

		return result.IsSuccess? Ok(result.Value): result.ToProblem();
	}

	[HttpGet("")]
	[HasPermission(Permissions.GetMenuCategories)]
	public async Task<IActionResult> GetAll([FromQuery]RequestFilters filters,CancellationToken cancellationToken = default)
	{	
		var result=await _mediator.Send(new GetAllMenuCategoriesQuery(filters), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	[HasPermission(Permissions.AddMenuCategories)]
	public async Task<IActionResult> Create([FromBody] MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddMenuCategoryCommand(request),cancellationToken);

		return result.IsSuccess? CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value) : result.ToProblem();
	}

	[HttpPut("{id}")]
	[HasPermission(Permissions.UpdateMenuCategories)]
	public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MenuCategoryRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdateMenuCategoryCommand(id, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

	[HttpPut("{id}/toggleStatus")]
	[HasPermission(Permissions.UpdateMenuCategories)]
	public async Task<IActionResult> ToggleStatus( [FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ToggleMenuCategoryStatusCommand(id),cancellationToken);

		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

}
