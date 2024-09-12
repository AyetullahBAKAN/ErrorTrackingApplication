using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class UnitService : Service<Unit>
    {
        private readonly IMapper _mapper;
        public UnitService(IGenericRepository<Unit> repository, IUnitOfWork unitOfWork, 
                           IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<UnitDto>> GetUnitListAsync()
        {
            try
            {
                var unitList = await GetListAsync(x => !x.IsDeleted);
                var unitListDto = _mapper.Map<List<UnitDto>>(unitList.ToList());
                return unitListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
