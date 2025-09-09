using RestaurantProject.Application.Contracts.Invoice;

namespace RestaurantProject.Application.Features.Invoice.Commands.Models;
public record AddInvoiceCommand(int OrderId,InvoiceRequest InvoiceRequest) : IRequest<Result<InvoiceResponse>>;
