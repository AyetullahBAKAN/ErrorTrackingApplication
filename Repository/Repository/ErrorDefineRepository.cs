using Core.Models;

namespace Repository.Repository
{
    public class ErrorDefineRepository : GenericRepository<ErrorDefine>
    {
        public ErrorDefineRepository(AppDbContext context) : base(context)
        {
        }
    }
}
