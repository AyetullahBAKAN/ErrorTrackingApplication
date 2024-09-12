using Core.DTOs;
using Core.Models;

namespace Core.IService
{
    public interface IPartService:IService<Part>
    {
        Task<CustomResponseDto<List<PartDto>>> GetPart();
    }
}
