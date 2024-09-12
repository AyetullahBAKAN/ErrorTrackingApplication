using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class CostService : Service<Cost>
    {
        private readonly IMapper _mapper;
        public CostService(IGenericRepository<Cost> repository, 
                            IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<CostDto>> GetCostListAsync()
        {
            try
            {
                var costList = await GetListAsync(x => !x.IsDeleted
                , null,
                    "Field," +
                    "MoneyType,"
                    );

                var costListDto = _mapper.Map<List<CostDto>>(costList.ToList());

                return costListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
