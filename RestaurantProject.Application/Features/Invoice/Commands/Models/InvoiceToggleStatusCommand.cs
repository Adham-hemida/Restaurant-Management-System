namespace RestaurantProject.Application.Features.Invoice.Commands.Models;
public record InvoiceToggleStatusCommand(int OrderId, int InvoiceId) : IRequest<Result>;
