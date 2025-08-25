using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Entites;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class FileService (IWebHostEnvironment webHostEnvironment,
	IUploadedFileRepository uploadedFileRepository,
	IMenuItemRepository menuItemRepository) : IFileService
{
	private readonly string _imagePath = $"{webHostEnvironment.WebRootPath}/images";
	private readonly IUploadedFileRepository _uploadedFileRepository = uploadedFileRepository;
	private readonly IMenuItemRepository _menuItemRepository = menuItemRepository;

	public async Task<Result> UploadImageAsync(int menuItemId, UploadImageRequest request, CancellationToken cancellationToken = default)
	{
		var menuItemIsExist = await _menuItemRepository.GetAsQueryable().AnyAsync(x => x.Id == menuItemId && x.IsActive, cancellationToken);
		if (!menuItemIsExist)
			return Result.Failure(MenuItemErrors.MenuItemNotFound);

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

