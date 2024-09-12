using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorDefineService : Service<ErrorDefine>
    {
        private readonly IMapper _mapper;
        public ErrorDefineService(IGenericRepository<ErrorDefine> repository,
                                  IUnitOfWork unitOfWork,
                                  IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<ErrorDefineDto>> GetErrorDefineListAsync()
        {
            try
            {
                var errorDefineList = await GetListAsync(x => !x.IsDeleted);

                var errorDefineListDto = _mapper.Map<List<ErrorDefineDto>>(errorDefineList.ToList());

                return errorDefineListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
