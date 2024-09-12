using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class StateService : Service<State>
    {
        private readonly IMapper _mapper;
        public StateService(IGenericRepository<State> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<StateDto>> GetStateListAsync()
        {
            try
            {
                var stateList = await GetListAsync(x => !x.IsDeleted);
                var stateListDto = _mapper.Map<List<StateDto>>(stateList.ToList());
                return stateListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
