using Core.Models;

namespace Repository.Repository
{
    public class ErrorSubGroupRepository : GenericRepository<ErrorSubGroup>
    {
        public ErrorSubGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
