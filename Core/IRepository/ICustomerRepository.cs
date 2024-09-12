using Core.Models;

namespace Core.IRepository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Project>> GetCustomerByIdWithProjectListAsync(Guid customerId);
    }
}
