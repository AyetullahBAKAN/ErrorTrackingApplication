using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class PatternService : Service<Pattern>
    {
        private readonly IMapper _mapper;
        public PatternService(IGenericRepository<Pattern> repository, IUnitOfWork unitOfWork,
                              IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<PatternDto>> GetPatternListAsync()
        {
            try
            {
                var patternList = await GetListAsync(x => !x.IsDeleted
                , null,
                    "Project," +
                    "Customer," +
                    "MontageLetter," +
                    "Part," +
                    "Operation,"
                    );

                var patternListDto = _mapper.Map<List<PatternDto>>(patternList.ToList());

                return patternListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
