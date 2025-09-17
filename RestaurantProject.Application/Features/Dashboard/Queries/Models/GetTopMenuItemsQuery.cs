using RestaurantProject.Application.Contracts.Dashboard;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Models;
public record GetTopMenuItemsQuery(DateTime Date) : IRequest<Result<IEnumerable<TopMenuItemResponse>>>;