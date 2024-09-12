using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class PartService : Service<Part>
    {
        private readonly IMapper _mapper;

        public PartService(IGenericRepository<Part> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<PartDto>> GetPartListAsync()
        {
            try
            {
                var partList = await GetListAsync(x => !x.IsDeleted);
                var partListDto = _mapper.Map<List<PartDto>>(partList.ToList());
                return partListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
