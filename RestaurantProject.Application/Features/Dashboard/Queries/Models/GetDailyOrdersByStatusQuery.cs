using RestaurantProject.Application.Contracts.Dashboard;

namespace RestaurantProject.Application.Features.Dashboard.Queries.Models;
public record GetDailyOrdersByStatusQuery(DateTime Date) : IRequest<Result<IEnumerable<OrderStatusCountResponse>>>;
