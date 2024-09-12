using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class MontageLetterRepository : GenericRepository<MontageLetter>, IMontageLetterRepository
    {

        public MontageLetterRepository(AppDbContext _context) : base(_context) { }


        public async Task<List<MontageLetter>> GetMontageLetters()
        {
            return await _context.MontageLetter.Include(x=>x.MontageNumber).ToListAsync();
        }
    }
}
