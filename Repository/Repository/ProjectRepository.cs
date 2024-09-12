using Core.IRepository;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.Repository
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {

        }
        public async Task<List<Project>> GetProjectWithCustomers()
        {
            return await _context.Project?.Include(x => x.Customer)?.ToListAsync();

        }
    }
}
