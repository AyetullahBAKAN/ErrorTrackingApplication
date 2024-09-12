using Core.Models;

namespace Repository.Repository
{
    public class ErrorDetectionLocationRepository : GenericRepository<ErrorDetectionLocation>
    {
        public ErrorDetectionLocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
