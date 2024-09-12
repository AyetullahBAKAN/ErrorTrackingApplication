using Core.Models;

namespace Repository.Repository
{
    public class ErrorMainTitleRepository : GenericRepository<ErrorMainTitle>
    {
        public ErrorMainTitleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
