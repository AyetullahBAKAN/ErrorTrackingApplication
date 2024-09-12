using Core.Models;

namespace Repository.Repository
{
    public class FieldRepository : GenericRepository<Field>
    {
        public FieldRepository(AppDbContext context) : base(context)
        {
        }
    }
}
