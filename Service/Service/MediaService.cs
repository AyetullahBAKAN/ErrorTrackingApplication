using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class MediaService : Service<Media>
    {
        private readonly IMapper _mapper;
        public MediaService(IGenericRepository<Media> repository, IUnitOfWork unitOfWork, 
                            IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<List<MediaDto>> GetMediaListAsync()
        {
            try
            {
                var mediaList = await GetListAsync(x => !x.IsDeleted);
                var mediaListDto = _mapper.Map<List<MediaDto>>(mediaList.ToList());
                return mediaListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
