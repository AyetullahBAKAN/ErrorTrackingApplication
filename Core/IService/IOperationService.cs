using Core.DTOs;
using Core.Models;

namespace Core.IService
{
    public interface IOperationService:IService<Operation>
    {
        Task<CustomResponseDto<List<OperationDto>>> GetOperation();
        
    }
}
