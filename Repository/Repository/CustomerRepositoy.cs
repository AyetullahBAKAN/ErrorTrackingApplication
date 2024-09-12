using Core.IRepository;
using Microsoft.EntityFrameworkCore;
using Core.Models;

namespace Repository.Repository
{
    public class CustomerRepositoy : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepositoy(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Project>> GetCustomerByIdWithProjectListAsync(Guid customerId)
        {
            return await _context.Project.Where(x => x.CustomerId == customerId && !x.IsDeleted).ToListAsync();
        }
    }
}
