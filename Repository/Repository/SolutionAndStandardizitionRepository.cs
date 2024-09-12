using Core.Models;

namespace Repository.Repository
{
    public class SolutionAndStandardizitionRepository : GenericRepository<SolutionAndStandardizition>
    {
        public SolutionAndStandardizitionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
