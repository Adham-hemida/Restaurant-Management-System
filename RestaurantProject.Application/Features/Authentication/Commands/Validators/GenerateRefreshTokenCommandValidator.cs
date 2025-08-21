namespace RestaurantProject.Application.Features.Authentication.Commands.Validators;
public class GenerateRefreshTokenCommandValidator : AbstractValidator<GenerateRefreshTokenCommand>
{
	public GenerateRefreshTokenCommandValidator()
	{
		RuleFor(x => x.RefreshTokenRequest)
			.NotNull()
			.WithMessage("Refresh token request cannot be null.")
			.SetValidator(new RefreshTokenRequestValidator());
	}
}
