using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.Features.Invoice.Commands.Models;

namespace RestaurantProject.Application.Features.Invoice.Commands.Handlers;
public class AddInvoiceCommandHandler(IInvoiceService invoiceService) : IRequestHandler<AddInvoiceCommand, Result<InvoiceResponse>>
{
	private readonly IInvoiceService _invoiceService = invoiceService;

	public async Task<Result<InvoiceResponse>> Handle(AddInvoiceCommand request, CancellationToken cancellationToken)
	{
		return await _invoiceService.AddAsync(request.OrderId, request.InvoiceRequest, cancellationToken);
	}
}
