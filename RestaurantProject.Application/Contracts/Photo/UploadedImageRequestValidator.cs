using RestaurantProject.Application.Contracts.Common;
using RestaurantProject.Application.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace RestaurantProject.Application.Contracts.Photo;
public class UploadImageRequestValidator : AbstractValidator<UploadImageRequest>
{
	public UploadImageRequestValidator()
	{
		RuleFor(x => x.Image)
			.SetValidator(new FileSizeValidator())
			.SetValidator(new BlockedSignatureValidator());

		RuleFor(x => x.Image)
			.Must((request, context) =>
			{
				var extension = Path.GetExtension(request.Image.FileName.ToLower());
				return FileSettings.AllowedImageExtensions.Contains(extension);
			})
			.WithMessage("File Extension is not allowed")
			.When(x => x.Image is not null);
	}
}