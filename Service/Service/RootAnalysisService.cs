using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class RootAnalysisService:Service<RootAnalysis>
    {
        private readonly IMapper _mapper;
        public RootAnalysisService(IMapper mapper,IGenericRepository<RootAnalysis> repository,
                                    IUnitOfWork unitOfWork):base(repository,unitOfWork)
        {
            _mapper = mapper;
        }
        public async Task<List<RootAnalysisDto>> GetRootAnalysisListAsync()
        {
            try
            {
                var rootList = await GetListAsync(x => !x.IsDeleted);
                var rootListDto = _mapper.Map<List<RootAnalysisDto>>(rootList.ToList());
                return rootListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
