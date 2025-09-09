using RestaurantProject.Application.Contracts.Invoice;

namespace RestaurantProject.Application.Features.Invoice.Queries.Models;
public record GetInvoiceQuery (int OrderId , int InvoiceId) : IRequest<Result<InvoiceResponse>>;
