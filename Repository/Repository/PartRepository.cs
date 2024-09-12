using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class PartRepository : GenericRepository<Part>, IPartRepository
    {
        public PartRepository(AppDbContext _context) : base(_context) { }

        public async Task<List<Part>> GetPart()
        {
            return await _context.Part.Include(x=>x.PartNo).ToListAsync();
        }
    }
}
