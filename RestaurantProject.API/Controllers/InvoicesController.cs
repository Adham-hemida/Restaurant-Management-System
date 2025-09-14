using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Contracts.Order;
using RestaurantProject.Application.Contracts.OrderItem;
using RestaurantProject.Application.Features.Invoice.Commands.Models;
using RestaurantProject.Application.Features.Invoice.Queries.Models;
using RestaurantProject.Application.Features.MenuItem.Queries.Models;
using RestaurantProject.Application.Features.Order.Commands.Models;
using RestaurantProject.Application.Features.OrderItem.Commands.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/Order/{orderId}/[controller]")]
[ApiController]
public class InvoicesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("{id}")]
	[HasPermission(Permissions.GetInvoices)]
	public async Task<IActionResult> GetById([FromRoute] int orderId, [FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new GetInvoiceQuery(orderId, id), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}


	[HttpPost("")]
	[HasPermission(Permissions.AddInvoices)]
	public async Task<IActionResult> Create([FromRoute] int orderId, [FromBody] InvoiceRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new AddInvoiceCommand(orderId, request), cancellationToken);

		return result.IsSuccess 
			?CreatedAtAction(nameof(GetById),new { result.Value.Id},result.Value)	
			: result.ToProblem();
	}

	[HttpPut("{id}/update-pay-method")]
	[HasPermission(Permissions.UpdateInvoices)]
	public async Task<IActionResult> UpdatePayMenthod([FromRoute] int orderId, [FromRoute] int id, [FromBody] UpdateInvoicePaymentMethodRequest  request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UpdatePayMenthodCommand(orderId,id, request), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}
	
	[HttpPut("{id}/toggle-status")]
	[HasPermission(Permissions.UpdateInvoices)]
	public async Task<IActionResult> ToggleStatus([FromRoute] int orderId, [FromRoute] int id, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new InvoiceToggleStatusCommand(orderId,id), cancellationToken);
		return result.IsSuccess ? NoContent() : result.ToProblem();
	}

}
