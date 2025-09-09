using RestaurantProject.Application.Contracts.Invoice;

namespace RestaurantProject.Application.Interfaces.IService;
public interface IInvoiceService
{
	Task<Result<InvoiceResponse>> AddAsync(int orderId, InvoiceRequest request, CancellationToken cancellationToken = default);
	Task<Result<InvoiceResponse>> GetAsync(int orderId, int id, CancellationToken cancellationToken = default);
	Task<Result> UpdatePayMenthodAsync(int orderId, int id, UpdateInvoicePaymentMethodRequest request, CancellationToken cancellationToken = default);
	Task<Result> ToggleStatusAsync(int orderId, int id, CancellationToken cancellationToken = default);

}
