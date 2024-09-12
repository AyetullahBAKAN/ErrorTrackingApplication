using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IService;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ProjectService : Service<Project>
    {
        private readonly IMapper _mapper;
        private readonly IService<Project> _service;
        private readonly IUnitOfWork _unitOfWork;
        public ProjectService(IGenericRepository<Project> repository, IUnitOfWork unitOfWork,
                             IMapper mapper, IService<Project> service) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _service = service;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ProjectDto>> GetProjectListAsync()
        {
            try
            {
                var projectList = await GetListAsync(x => !x.IsDeleted, null, "Customer,");

                var projectListDto = _mapper.Map<List<ProjectDto>>(projectList.ToList());
                return projectListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        

    }
}
