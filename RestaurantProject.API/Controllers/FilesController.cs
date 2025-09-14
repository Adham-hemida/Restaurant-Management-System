using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Abstractions.Consts;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.Features.UploadFile.Command.Models;
using RestaurantProject.Infrastructure.Permission;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FilesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost("{menuItemId}/upload-image")]
	[HasPermission(Permissions.UploadFiles)]
	public async Task<IActionResult> UploadImage([FromRoute]int menuItemId,[FromForm] UploadImageRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UploadImageCommand(menuItemId,request), cancellationToken);
		return result.IsSuccess?Created():result.ToProblem();
	}
}
