namespace RestaurantProject.Infrastructure.Implementaion.Repositories;
public class UploadedFileRepository : GenericRepository<UploadedFile>, IUploadedFileRepository
{
	public UploadedFileRepository(ApplicationDbContext context) : base(context)
	{
	}
}
