using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorSubGroupService : Service<ErrorSubGroup>
    {
        private readonly IMapper _mapper;
        public ErrorSubGroupService(IGenericRepository<ErrorSubGroup> repository, 
                                    IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorSubGroupDto>> GetErrorSubGroupsAsync()
        {
            try
            {
                var errorSubGroupList = await GetListAsync(x => !x.IsDeleted);

                var errorSubGroupListDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroupList.ToList());

                return errorSubGroupListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
