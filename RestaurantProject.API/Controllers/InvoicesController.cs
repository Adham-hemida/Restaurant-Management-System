using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.Invoice.Commands.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/[controller]")]
[ApiController]
[Authorize]
public class InvoicesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost("")]
	public async Task<IActionResult> Create([FromRoute] int orderId, [FromBody] InvoiceRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddInvoiceCommand(orderId, request), cancellationToken);

		return result.IsSuccess ?Ok(result.Value)	: result.ToProblem();
	}

}
