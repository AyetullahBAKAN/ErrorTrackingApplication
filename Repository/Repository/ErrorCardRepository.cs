using Core.Models;

namespace Repository.Repository
{
    public class ErrorCardRepository : GenericRepository<ErrorCard>
    {
        public ErrorCardRepository(AppDbContext context) : base(context)
        {
        }
    }
}
