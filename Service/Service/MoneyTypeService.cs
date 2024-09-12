using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class MoneyTypeService : Service<MoneyType>
    {
        private readonly IMapper _mapper;
        public MoneyTypeService(IGenericRepository<MoneyType> repository, IUnitOfWork unitOfWork, IMapper mapper  ) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<MoneyTypeDto>> GetMoneyTypeListAsync()
        {
            try
            {
                var moneyList = await GetListAsync(x => !x.IsDeleted);
                var moneyListDto = _mapper.Map<List<MoneyTypeDto>>(moneyList.ToList());
                return moneyListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
