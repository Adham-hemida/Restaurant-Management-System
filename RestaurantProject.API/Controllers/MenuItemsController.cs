using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/MenuCategories/{menuCategoryId}/[controller]")]
[ApiController]
[Authorize]
public class MenuItemsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{menuItemd}")]
	public async Task<IActionResult> GetById([FromRoute] int menuCategoryId, [FromRoute] int menuItemd, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetMenuItemQuery(menuCategoryId, menuItemd), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}


}
