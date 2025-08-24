using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.Features.UploadFile.Command.Models;

namespace RestaurantProject.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FilesController(IMediator mediator) : ControllerBase
{
	private readonly IMediator _mediator = mediator;

	[HttpPost("{menuItemId}/upload-image")]
	public async Task<IActionResult> UploadImage([FromRoute]int menuItemId,[FromForm] UploadImageRequest request, CancellationToken cancellationToken)
	{
		var result = await _mediator.Send(new UploadImageCommand(menuItemId,request), cancellationToken);
		return Created();
	}
}
