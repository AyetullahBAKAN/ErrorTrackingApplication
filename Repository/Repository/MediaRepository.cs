using Core.Models;

namespace Repository.Repository
{
    public class MediaRepository : GenericRepository<Media>
    {
        public MediaRepository(AppDbContext context) : base(context)
        {
        }
    }
}
