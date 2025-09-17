using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Features.Dashboard.Queries.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[HasPermission(Permissions.Results)]
public class DashboardsController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpGet("daily-revenue")]
	public async Task<IActionResult> GetDailyRevenue([FromQuery] DateTime date, CancellationToken cancellationToken = default)
	{
		var result = await _mediator.Send(new GetDailyRevenueQuery(date), cancellationToken);
		return result.IsSuccess ? Ok(result.Value) : result.ToProblem();
	}
}
