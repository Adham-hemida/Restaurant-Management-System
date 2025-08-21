namespace RestaurantProject.Application.Features.Authentication.Commands.Validators;

public class RevokeRefreshTokenCommandValidator : AbstractValidator<RevokeRefreshTokenCommand>
{
	public RevokeRefreshTokenCommandValidator()
	{
		RuleFor(x => x.RefreshTokenRequest)
			.NotNull()
			.WithMessage("Refresh token request cannot be null.")
			.SetValidator(new RefreshTokenRequestValidator());
	}
}
