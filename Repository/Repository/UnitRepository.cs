using Core.Models;

namespace Repository.Repository
{
    public class UnitRepository : GenericRepository<Unit>
    {
        public UnitRepository(AppDbContext context) : base(context)
        {

        }
    }
}
