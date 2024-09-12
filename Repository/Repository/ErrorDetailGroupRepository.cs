using Core.Models;

namespace Repository.Repository
{
    public class ErrorDetailGroupRepository : GenericRepository<ErrorDetailGroup>
    {
        public ErrorDetailGroupRepository(AppDbContext context) : base(context)
        {
        }
    }
}
