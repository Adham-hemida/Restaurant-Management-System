namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
{
	public InvoiceRepository(ApplicationDbContext context):base(context)
	{
		
	}
}
