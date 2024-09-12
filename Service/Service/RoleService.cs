using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class RoleService : Service<Role>
    {
        private readonly IMapper _mapper;
        public RoleService(IGenericRepository<Role> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<RoleDto>> GetRoleListAsync()
        {
            try
            {
                var roleList = await GetListAsync(x => !x.IsDeleted);
                var roleListDto = _mapper.Map<List<RoleDto>>(roleList.ToList());
                return roleListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
