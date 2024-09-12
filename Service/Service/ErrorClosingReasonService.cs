using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorClosingReasonService : Service<ErrorClosingReason>
    {
        private readonly IMapper _mapper;
        public ErrorClosingReasonService(IGenericRepository<ErrorClosingReason> repository, 
                                        IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorClosingReasonDto>> GetErrorClosingReasonListAsync()
        {
            try
            {
                var classList = await GetListAsync(x => !x.IsDeleted);

                var classListDto = _mapper.Map<List<ErrorClosingReasonDto>>(classList.ToList());

                return classListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
