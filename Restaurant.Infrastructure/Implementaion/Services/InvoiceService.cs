using Mapster;
using RestaurantProject.Application.Abstractions;
using RestaurantProject.Application.Contracts.Invoice;
using RestaurantProject.Application.ErrorHandler;
using RestaurantProject.Application.Interfaces.IService;
using RestaurantProject.Domain.Consts;

namespace RestaurantProject.Infrastructure.Implementaion.Services;
public class InvoiceService(IInvoiceRepository invoiceRepository,
	IOrderRepository orderRepository
	) : IInvoiceService
{
	private readonly IInvoiceRepository _invoiceRepository = invoiceRepository;
	private readonly IOrderRepository _orderRepository = orderRepository;

	public async Task<Result<InvoiceResponse>> GetAsync(int orderId, int id, CancellationToken cancellationToken = default)
	{
		var orderIsExist = await _orderRepository.GetAsQueryable()
			.AnyAsync(x => x.Id == orderId && x.IsActive, cancellationToken);

		if (!orderIsExist)
			return Result.Failure<InvoiceResponse>(OrderErrors.OrderNotFound);

		var invoice = await _invoiceRepository.GetAsQueryable()
					.Where(i => i.OrderId == orderId && i.Id==id)
					.Include(i => i.Order)
				      .ThenInclude(o => o.OrderItems)
		             	.ThenInclude(oi => oi.MenuItem)
					.Select(i => new InvoiceResponse(
						i.Id,
						i.TotalAmount,
						i.PaymentMethod,
						i.Tax,
						i.ServiceCharge,
						i.FinalAmount,
						new InvoiceOfOrderResponse(
							i.Order.Id,
							i.Order.Name,
							i.Order.OrderItems.Select(oi => new InvoiceOfOrderItemsResponse(
								oi.MenuItem.Name,
								oi.Quantity,
								oi.TotalPrice
								)).ToList()
							)
						))
					.SingleOrDefaultAsync(cancellationToken);

		if (invoice is null)
			return Result.Failure<InvoiceResponse>(InvoiceErrors.InvoiceNotFound);

		return Result.Success(invoice);
	}



	public async Task<Result<InvoiceResponse>>AddAsync(int orderId,InvoiceRequest request,CancellationToken cancellationToken=default)
	{
		var order=await _orderRepository.GetAsQueryable()
		 .Where(o => o.Id == orderId)
		 .Include(o=>o.OrderItems)
		    .ThenInclude(oi => oi.MenuItem)
		 .SingleOrDefaultAsync(cancellationToken);

		if (order is null)
			return Result.Failure<InvoiceResponse>(OrderErrors.OrderNotFound);

		if(order.Status==OrderStatus.Cancelled)
			return Result.Failure<InvoiceResponse>(OrderErrors.OrderCancelled);

		var invoice = request.Adapt<Invoice>();
		invoice.OrderId = orderId;
		invoice.TotalAmount=order.TotalAmount;
		invoice.Tax = (request.TaxPercentage / 100) * order.TotalAmount;

		await _invoiceRepository.AddAsync(invoice, cancellationToken);

		var response=new InvoiceResponse(
			invoice.Id,
			invoice.TotalAmount,
			invoice.PaymentMethod,
			invoice.Tax,
			invoice.ServiceCharge,
			invoice.FinalAmount,
			new InvoiceOfOrderResponse(
				order.Id,
				order.Name,
				order.OrderItems.Select(oi=> new InvoiceOfOrderItemsResponse(
					oi.MenuItem.Name,
					oi.Quantity,
					oi.TotalPrice
					)).ToList()
				)
			);

		return Result.Success(response);

	}
}
