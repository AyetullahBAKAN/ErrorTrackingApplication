using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class OperationRepository:GenericRepository<Operation>,IOperationRepository
    {

        public OperationRepository(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Operation>> GetOperation()
        {
            return await _context.Operation.Include(x => x.OperationNo).ToListAsync();
        }
    }
}
