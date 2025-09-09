using RestaurantProject.Application.Features.Invoice.Commands.Models;

namespace RestaurantProject.Application.Features.Invoice.Commands.Handlers;
public class UpdatePayMenthodCommandHandler(IInvoiceService invoiceService) : IRequestHandler<UpdatePayMenthodCommand, Result>
{
	private readonly IInvoiceService _invoiceService = invoiceService;

	public async Task<Result> Handle(UpdatePayMenthodCommand request, CancellationToken cancellationToken)
	{
		return await _invoiceService.UpdatePayMenthodAsync(request.OrderId, request.InvoiceId, request.PaymentMethodRequest, cancellationToken);
	}
}
