using Core.Models;

namespace Repository.Repository
{

    public class ErrorClosingReasonRepository : GenericRepository<ErrorClosingReason>
    {
        public ErrorClosingReasonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
