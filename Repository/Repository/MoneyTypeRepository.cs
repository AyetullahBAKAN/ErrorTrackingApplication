using Core.Models;

namespace Repository.Repository
{
    public class MoneyTypeRepository : GenericRepository<MoneyType>
    {
        public MoneyTypeRepository(AppDbContext context) : base(context)
        {

        }
    }
}
