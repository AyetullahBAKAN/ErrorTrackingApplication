using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorMainTitleService : Service<ErrorMainTitle>
    {
        private readonly IMapper _mapper;
        public ErrorMainTitleService(IGenericRepository<ErrorMainTitle> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorMainTitleDto>> GetErrorMainTitleAsync()
        {
            try
            {
                var errorMainList = await GetListAsync(x => !x.IsDeleted);

                var errorMainListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainList.ToList());

                return errorMainListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
