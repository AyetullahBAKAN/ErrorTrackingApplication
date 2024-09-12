using Core.Models;

namespace Core.IRepository
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<List<Project>> GetProjectWithCustomers();

    }
}
