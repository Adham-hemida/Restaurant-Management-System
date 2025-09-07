using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Features.Order.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Queries.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrdersController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetOrderQuery(id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}


}
