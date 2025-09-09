using RestaurantProject.Application.Features.Invoice.Commands.Models;

namespace RestaurantProject.Application.Features.Invoice.Commands.Handlers;
public class InvoiceToggleStatusCommandHandler (IInvoiceService invoiceService) : IRequestHandler<InvoiceToggleStatusCommand, Result>
{
	private readonly IInvoiceService _invoiceService = invoiceService;
	public async Task<Result> Handle(InvoiceToggleStatusCommand request, CancellationToken cancellationToken)
	{
		return await _invoiceService.ToggleStatusAsync(request.OrderId, request.InvoiceId, cancellationToken);
	}
}
