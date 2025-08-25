using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Contracts.MenuItem;
using RestaurantProject.Application.Features.MenuItem.Commands.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/MenuCategories/{menuCategoryId}/[controller]")]
[ApiController]
[Authorize]
public class MenuItemsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{menuItemId}")]
	public async Task<IActionResult> GetById([FromRoute] int menuCategoryId, [FromRoute] int menuItemId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuItemQuery(menuCategoryId, menuItemId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}
	[HttpGet("{menuItemId}/with-images")]
	public async Task<IActionResult> GetMenuItemWithImages([FromRoute] int menuCategoryId, [FromRoute] int menuItemId, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuItemWithImagesQuery(menuCategoryId, menuItemId), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpGet("")]
	public async Task<IActionResult> GetAll([FromRoute] int menuCategoryId, [FromQuery] RequestFilters filters, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetAllMenuItemsQuery(menuCategoryId,filters),cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}

	[HttpPost("")]
	public async Task<IActionResult> Create([FromRoute] int menuCategoryId, [FromBody] MenuItemRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddMenuItemCommand(menuCategoryId, request), cancellationToken);

		return result.IsSuccess
			? CreatedAtAction(nameof(GetById), new { menuCategoryId, menuItemId=result.Value.Id }, result.Value)
			: result.ToProblem();
	}

	[HttpPut("{menuItemId}")]
	public async Task<IActionResult> Update([FromRoute] int menuCategoryId, [FromRoute] int menuItemId, [FromBody] MenuItemRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdateMenuItemCommand(menuCategoryId, menuItemId, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpPut("{menuItemId}/change-price")]
	public async Task<IActionResult> ChangePrice([FromRoute] int menuCategoryId, [FromRoute] int menuItemId, [FromBody]ChangePriceRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new ChangePriceCommand(menuCategoryId, menuItemId, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
}
