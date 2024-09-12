using Core.DTOs;
using Core.Models;

namespace Core.IService
{
    public interface ICustomerService:IService<Customer>
    {
        public Task<CustomResponseDto<List<ProjectDto>>> GetCustomerByIdWithProjectListAsync(Guid customerId);
    }
}
