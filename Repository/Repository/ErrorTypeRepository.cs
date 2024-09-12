using Core.Models;

namespace Repository.Repository
{
    public class ErrorTypeRepository : GenericRepository<ErrorType>
    {
        public ErrorTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
