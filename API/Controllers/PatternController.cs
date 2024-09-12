using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace API.Controllers
{

    public class PatternController : CustomBaseController
    {   
        private readonly PatternService _patternService;
        private readonly IService<Pattern> _service;
        private readonly IMapper _mapper;
        public PatternController(IMapper mapper, IService<Pattern> service, PatternService patternService)
        {
            _mapper = mapper;
            _service = service;
            _patternService = patternService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pattern = await _patternService.GetPatternListAsync();
            var patternDto = _mapper.Map<List<PatternDto>>(pattern.ToList());
            return CreateActionResult(CustomResponseDto<List<PatternDto>>.Success(200, patternDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pattern = await _service.GetByIdAsync(id);
            var patternDto = _mapper.Map<PatternDto>(pattern);
            return CreateActionResult(CustomResponseDto<PatternDto>.Success(200, patternDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(PatternDto patternDto)
        {
            var patterns = await _service.AddAsync(_mapper.Map<Pattern>(patternDto));
            patterns.IsDeleted = false;
            var patternDtos = _mapper.Map<PatternDto>(patterns);

            return CreateActionResult(CustomResponseDto<PatternDto>.Success(201, patternDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(PatternDto patternDto)
        {
            await _service.UpdateAsync(_mapper.Map<Pattern>(patternDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var pattern = await _service.GetByIdAsync(id);

            pattern.IsDeleted = true;

            await _service.UpdateAsync(pattern);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
