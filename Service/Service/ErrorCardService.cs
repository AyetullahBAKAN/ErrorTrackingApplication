using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;


namespace Service.Service
{
    public class ErrorCardService : Service<ErrorCard>
    {
        private readonly IMapper _mapper;
        public ErrorCardService(IGenericRepository<ErrorCard> repository, 
            IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<ErrorCardDto>> GetErrorCardAsync()
        {
            try
            {
                var errorCardList = await GetListAsync(x=>!x.IsDeleted
                ,null,
                    "User," +
                    "Pattern,"+
                    "Pattern.Project," +
                    "Pattern.Customer," +
                    "Pattern.MontageLetter," +
                    "Pattern.Part," +
                    "Pattern.Operation," +
                    "RootAnalysis,"+
                    "States"
                    );

                var errorCardMapperDto = _mapper.Map<List<ErrorCardDto>>(errorCardList.ToList());

                return errorCardMapperDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
