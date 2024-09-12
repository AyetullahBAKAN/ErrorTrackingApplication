using Core.Models;

namespace Repository.Repository
{
    public class MailRepository : GenericRepository<Mail>
    {
        public MailRepository(AppDbContext context) : base(context)
        {

        }
    }
}
