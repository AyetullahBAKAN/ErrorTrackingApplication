using Core.DTOs;
using Core.Models;

namespace Core.IService
{
    public interface IProjectService:IService<Project>
    {
      public  Task<CustomResponseDto<List<ProjectDto>>> GetProjectWithCustomers();
    }
}
