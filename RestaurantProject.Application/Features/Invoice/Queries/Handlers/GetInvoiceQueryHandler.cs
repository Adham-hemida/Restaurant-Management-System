using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Features.Invoice.Queries.Models;

namespace RestaurantProject.Application.Features.Invoice.Queries.Handlers;
public class GetInvoiceQueryHandler(IInvoiceService invoiceService) : IRequestHandler<GetInvoiceQuery, Result<InvoiceResponse>>
{
	private readonly IInvoiceService _invoiceService = invoiceService;

	public async Task<Result<InvoiceResponse>> Handle(GetInvoiceQuery request, CancellationToken cancellationToken)
	{
		return await _invoiceService.GetAsync(request.OrderId, request.InvoiceId, cancellationToken);
	}
}
