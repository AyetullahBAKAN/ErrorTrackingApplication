using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class ErrorDetectionLocationService : Service<ErrorDetectionLocation>
    {
        private readonly IMapper _mapper;
        public ErrorDetectionLocationService(IGenericRepository<ErrorDetectionLocation> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorDetectionLocationDto>> GetErrorDetectionListAsync()
        {
            try
            {
                var errorList = await GetListAsync(x => !x.IsDeleted);
                var errorListDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorList.ToList());
                return errorListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
