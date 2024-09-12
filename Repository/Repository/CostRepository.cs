using Core.Models;

namespace Repository.Repository
{
    public class CostRepository : GenericRepository<Cost>
    {
        public CostRepository(AppDbContext context) : base(context)
        {
        }
    }
}
