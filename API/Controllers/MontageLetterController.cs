using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class MontageLetterController : CustomBaseController
    {

        private readonly IService<MontageLetter> _montageLetterService;
        private readonly IMapper _mapper;

        public MontageLetterController(IMapper mapper, IService<MontageLetter> montageLetterService)
        {
            _mapper = mapper;
            _montageLetterService = montageLetterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var montageLetter = await _montageLetterService.GetAllAsync();
            var montageLetterDto = _mapper.Map<List<MontageLetterDto>>(montageLetter.ToList());
            return CreateActionResult(CustomResponseDto<List<MontageLetterDto>>.Success(200, montageLetterDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var montageLetter = await _montageLetterService.GetByIdAsync(id);
            var montageLetterDto = _mapper.Map<MontageLetterDto>(montageLetter);
            return CreateActionResult(CustomResponseDto<MontageLetterDto>.Success(200, montageLetterDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(MontageLetterDto montageLetterDto)
        {
            var montageLetters = await _montageLetterService.AddAsync(_mapper.Map<MontageLetter>(montageLetterDto));
            montageLetters.IsDeleted = false;
            var montageLetterDtos = _mapper.Map<MontageLetterDto>(montageLetters);

            return CreateActionResult(CustomResponseDto<MontageLetterDto>.Success(201, montageLetterDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(MontageLetterDto montageLetterDto)
        {
            await _montageLetterService.UpdateAsync(_mapper.Map<MontageLetter>(montageLetterDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var montageLetter = await _montageLetterService.GetByIdAsync(id);

            montageLetter.IsDeleted = true;

            await _montageLetterService.UpdateAsync(montageLetter);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
