using RestaurantProject.Application.Features.UploadFile.Command.Models;

namespace RestaurantProject.Application.Features.UploadFile.Command.Handlers;
public class UploadImageCommandHandler(IFileService fileService) : IRequestHandler<UploadImageCommand, Result>
{
	private readonly IFileService _fileService = fileService;

	public async Task<Result> Handle(UploadImageCommand request, CancellationToken cancellationToken)
	{
		return await _fileService.UploadImageAsync(request.MenuItemId, request.UploadImageRequest, cancellationToken);
	}
}

