using Microsoft.AspNetCore.Http;

namespace RestaurantProject.Application.Contracts.Photo;
public record UploadImageRequest(IFormFile Image);
