using RestaurantProject.Application.Contracts.Photo;

namespace RestaurantProject.Application.Contracts.MenuItem;
public record MenuItemResponse(
	int Id,
	string Name,
	string Description,
	decimal Price,
	IEnumerable<UploadedFileResponse> UploadedFiles
	);
