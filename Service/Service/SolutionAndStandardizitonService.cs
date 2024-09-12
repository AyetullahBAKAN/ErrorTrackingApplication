using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class SolutionAndStandardizitonService : Service<SolutionAndStandardizition>
    {
        private readonly IMapper _mapper;
        public SolutionAndStandardizitonService(IGenericRepository<SolutionAndStandardizition> repository, 
                                    IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<SolutionAndStandardizitionDto>> GetSolutionandStandardizitionListAsync()
        {
            try
            {
                var solutionList = await GetListAsync(x => !x.IsDeleted, null,
                    "ErrorClosingReason,");

                var solutionListDto = _mapper.Map<List<SolutionAndStandardizitionDto>>(solutionList.ToList());

                return solutionListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
