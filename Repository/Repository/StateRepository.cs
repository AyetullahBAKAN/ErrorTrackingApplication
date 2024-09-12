using Core.Models;

namespace Repository.Repository
{
    public class StateRepository : GenericRepository<State>
    {
        public StateRepository(AppDbContext context) : base(context)
        {
        }
    }
}
