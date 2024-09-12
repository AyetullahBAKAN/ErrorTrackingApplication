using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SolutionAndStandardizitonController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<SolutionAndStandardizition> _service;

        public SolutionAndStandardizitonController(IMapper mapper, IService<SolutionAndStandardizition> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var solution = await _service.GetAllAsync();
            var solutionDto = _mapper.Map<List<SolutionAndStandardizitionDto>>(solution.ToList());

            return CreateActionResult(CustomResponseDto<List<SolutionAndStandardizitionDto>>.Success(200, solutionDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var solution = await _service.GetByIdAsync(id);
            var solutionDto = _mapper.Map<SolutionAndStandardizitionDto>(solution);
            return CreateActionResult(CustomResponseDto<SolutionAndStandardizitionDto>.Success(200, solutionDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(SolutionAndStandardizitionDto solutionDtos)
        {
            var solution = await _service.AddAsync(_mapper.Map<SolutionAndStandardizition>(solutionDtos));
            solution.IsDeleted = false;
            var solutionDto = _mapper.Map<SolutionAndStandardizitionDto>(solution);

            return CreateActionResult(CustomResponseDto<SolutionAndStandardizitionDto>.Success(201, solutionDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(SolutionAndStandardizitionDto solutionDtos)
        {
            await _service.UpdateAsync(_mapper.Map<SolutionAndStandardizition>(solutionDtos));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var solution = await _service.GetByIdAsync(id);

            solution.IsDeleted = true;

            await _service.UpdateAsync(solution);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
