using Core.Models;

namespace Repository.Repository
{
    public class RootAnalysisRepository:GenericRepository<RootAnalysis>
    {
        public RootAnalysisRepository(AppDbContext context):base(context)
        {
            
        }
    }
}
