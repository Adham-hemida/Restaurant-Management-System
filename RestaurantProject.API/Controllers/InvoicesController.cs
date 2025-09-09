using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.Invoice.Commands.Models;
using RestaurantProject.Application.Features.Invoice.Queries.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/[controller]")]
[ApiController]
[Authorize]
public class InvoicesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById([FromRoute] int orderId, [FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetInvoiceQuery(orderId, id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}


	[HttpPost("")]
	public async Task<IActionResult> Create([FromRoute] int orderId, [FromBody] InvoiceRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddInvoiceCommand(orderId, request), cancellationToken);

		return result.IsSuccess 
			?CreatedAtAction(nameof(GetById),new { result.Value.Id},result.Value)	
			: result.ToProblem();
	}

}
