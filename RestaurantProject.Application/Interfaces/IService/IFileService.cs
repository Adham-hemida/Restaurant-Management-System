using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Contracts.Photo;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IFileService
{
	public Task<Result> UploadImageAsync(int menuItem, UploadImageRequest request, CancellationToken cancellationToken = default);
}
