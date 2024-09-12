using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class OperationService : Service<Operation> 
    {
        private readonly IMapper _mapper;

        public OperationService(IGenericRepository<Operation> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        
        public async Task<List<OperationDto>> GetOperaiontListAsync()
        {
            try
            {
                var operationList = await GetListAsync(x => !x.IsDeleted);
                var operationListDto = _mapper.Map<List<OperationDto>>(operationList.ToList());
                return operationListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
