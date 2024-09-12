using Core.Models;

namespace Core.IRepository
{
    public interface IMontageLetterRepository:IGenericRepository<MontageLetter>
    {
        Task<List<MontageLetter>> GetMontageLetters();
    }
}
