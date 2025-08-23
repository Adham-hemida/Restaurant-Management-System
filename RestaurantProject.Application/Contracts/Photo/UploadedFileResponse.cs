namespace RestaurantProject.Application.Contracts.Photo;

public record UploadedFileResponse(
	Guid Id,
	string FileName,
	string Url
);