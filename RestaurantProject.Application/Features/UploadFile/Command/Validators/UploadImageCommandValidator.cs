using RestaurantProject.Application.Contracts.Photo;
using RestaurantProject.Application.Features.UploadFile.Command.Models;

namespace RestaurantProject.Application.Features.UploadFile.Command.Validators;
public class UploadImageCommandValidator : AbstractValidator<UploadImageCommand>
{
	public UploadImageCommandValidator()
	{
		RuleFor(x => x.UploadImageRequest)
			.NotNull()
			.WithMessage("UploadImageRequest cannot be null")
			.SetValidator(new UploadImageRequestValidator());
	}
}
