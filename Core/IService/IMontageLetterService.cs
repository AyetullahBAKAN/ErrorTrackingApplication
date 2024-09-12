using Core.DTOs;
using Core.Models;

namespace Core.IService
{
    public interface IMontageLetterService:IService<MontageLetter>
    {
        Task<CustomResponseDto<List<MontageLetterDto>>> GetMontageLetter();
    }
}
