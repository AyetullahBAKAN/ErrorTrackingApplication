using Core.Models;

namespace Repository.Repository
{
    public class PatternRepository : GenericRepository<Pattern>
    {
        public PatternRepository(AppDbContext context) : base(context) { }

    }
}
