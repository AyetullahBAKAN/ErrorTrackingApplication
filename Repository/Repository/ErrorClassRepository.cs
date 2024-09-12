using Core.Models;

namespace Repository.Repository
{
    public class ErrorClassRepository : GenericRepository<ErrorClass>
    {
        public ErrorClassRepository(AppDbContext context) : base(context)
        {
        }
    }
}
