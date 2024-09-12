using Core.Models;

namespace Repository.Repository
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(AppDbContext context) : base(context)
        {
        }
    }
}
