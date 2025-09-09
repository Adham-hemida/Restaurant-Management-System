using RestaurantProject.Application.Contracts.Invoice;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IInvoiceService
{
	Task<Result<InvoiceResponse>> AddAsync(int orderId, InvoiceRequest request, CancellationToken cancellationToken = default);

}
