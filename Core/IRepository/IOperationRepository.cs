using Core.Models;

namespace Core.IRepository
{
    public interface IOperationRepository: IGenericRepository<Operation>
    {
        Task<List<Operation>> GetOperation();
    }
}
