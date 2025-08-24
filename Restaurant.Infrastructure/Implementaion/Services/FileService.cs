using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class FileService (IWebHostEnvironment webHostEnvironment,IUploadedFileRepository uploadedFileRepository) : IFileService
{
	private readonly string _imagePath = $"{webHostEnvironment.WebRootPath}/images";
	private readonly IUploadedFileRepository _uploadedFileRepository = uploadedFileRepository;

	public async Task<Result> UploadImageAsync(int menuItemId, UploadImageRequest request, CancellationToken cancellationToken = default)
	{
		var path = Path.Combine(_imagePath, request.Image.FileName);

		using var stream = File.Create(path);
		await request.Image.CopyToAsync(stream, cancellationToken);

		var uploadedImage = new UploadedFile
		{
			FileName = request.Image.FileName,
			StoredFileName = request.Image.FileName,
			ContentType = request.Image.ContentType,
			FileExtension = Path.GetExtension(request.Image.FileName),
			MenuItemId = menuItemId
		};
		
		await _uploadedFileRepository.AddAsync(uploadedImage, cancellationToken);

		return Result.Success();
	}

}

