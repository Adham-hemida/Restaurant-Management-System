using RestaurantProject.Application.Contracts.Dashboard;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Models;
public record GetDailyRevenueQuery(DateTime Date) : IRequest<Result<DailyRevenueResponse>>;