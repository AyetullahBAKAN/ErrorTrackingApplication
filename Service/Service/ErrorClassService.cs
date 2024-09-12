using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorClassService : Service<ErrorClass>
    {
        private readonly IMapper _mapper;
        public ErrorClassService(IGenericRepository<ErrorClass> repository, IUnitOfWork unitOfWork, 
                                 IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorClassDto>> GetErrorClassListAsync()
        {
            try
            {
                var classList = await GetListAsync(x => !x.IsDeleted
                , null,
                    "ErrorMainTitle," +
                    "ErrorSubGroup,"
                    );

                var classListDto = _mapper.Map<List<ErrorClassDto>>(classList.ToList());

                return classListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
    }
}
