using Microsoft.AspNetCore.Http;
using RestaurantProject.Application.Settings;

namespace RestaurantProject.Application.Contracts.Common;
public class FileSizeValidator : AbstractValidator<IFormFile>
{
	public FileSizeValidator()
	{
		RuleFor(x => x)
			.Must((request, context) => request.Length <= FileSettings.MaxFileSizeInBytes)
			.WithMessage($"File size should be less  or equal  {FileSettings.MaxFileSizeInMB} MB.")
			.When(x => x is not null);
	}
}