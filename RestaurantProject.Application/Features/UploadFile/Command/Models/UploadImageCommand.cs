using RestaurantProject.Application.Contracts.Photo;

namespace RestaurantProject.Application.Features.UploadFile.Command.Models;
public record UploadImageCommand(int MenuItemId,UploadImageRequest UploadImageRequest) : IRequest<Result>;
