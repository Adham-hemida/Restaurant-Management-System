using RestaurantProject.Application.Contracts.Invoice;

namespace RestaurantProject.Application.Features.Invoice.Commands.Models;
public record UpdatePayMenthodCommand (int OrderId, int InvoiceId,UpdateInvoicePaymentMethodRequest PaymentMethodRequest) : IRequest<Result>;
