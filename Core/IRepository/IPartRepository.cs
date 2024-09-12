using Core.Models;

namespace Core.IRepository
{
    public interface IPartRepository:IGenericRepository<Part>
    {
        Task<List<Part>> GetPart();
    }
}
