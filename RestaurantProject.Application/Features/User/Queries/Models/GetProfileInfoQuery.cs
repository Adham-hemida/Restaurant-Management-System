namespace RestaurantProject.Application.Features.User.Queries.Models;
public record GetProfileInfoQuery(string UserId) : IRequest<Result<UserProfileResponse>>;
