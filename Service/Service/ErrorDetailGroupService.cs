using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorDetailGroupService : Service<ErrorDetailGroup>
    {
        private readonly IMapper _mapper;

        public ErrorDetailGroupService(IGenericRepository<ErrorDetailGroup> repository,
                                       IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorDetailGroupDto>> GetErrorDetailGroupsAsync()
        {
            try
            {
                var errorDetailGroupList = await GetListAsync(x => !x.IsDeleted);

                var errorDetailGroupMapperDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailGroupList.ToList());

                return errorDetailGroupMapperDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
