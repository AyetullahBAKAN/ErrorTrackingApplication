using AutoMapper;
using Core.DTOs;
using Core.IRepository;
using Core.IUnitOfWorks;
using Core.Models;

namespace Service.Service
{
    public class MontageLetterService : Service<MontageLetter>
    {

        private readonly IMapper _mapper;
        public MontageLetterService(IGenericRepository<MontageLetter> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork)
        {
            _mapper = mapper;
        }
        //public async Task<CustomResponseDto<List<MontageLetterDto>>> GetMontageLetter()
        //{
        //    var montageLetters = await _montageLetterRepository.GetMontageLetters();

        //    var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetters);

        //    return CustomResponseDto<List<MontageLetterDto>>.Success(200, montageLetterDto);
        //}

        public async Task<List<MontageLetterDto>> GetMontageLetterListAsync()
        {
            try
            {
                var montageLetterList = await GetListAsync(x => !x.IsDeleted);
                var montageLetterListDto = _mapper.Map<List<MontageLetterDto>>(montageLetterList.ToList());
                return montageLetterListDto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
