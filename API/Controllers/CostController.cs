using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.CostController
{

    public class CostController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Cost> _service;
        public CostController(IMapper mapper, IService<Cost> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cost = await _service.GetAllAsync();
            var costDto = _mapper.Map<List<CostDto>>(cost.ToList());

            return CreateActionResult(CustomResponseDto<List<CostDto>>.Success(200, costDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cost = await _service.GetByIdAsync(id);
            var costDto = _mapper.Map<CostDto>(cost);
            return CreateActionResult(CustomResponseDto<CostDto>.Success(200, costDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CostDto costDto)
        {
            var costs = await _service.AddAsync(_mapper.Map<Cost>(costDto));
            costs.IsDeleted = false;
            var costDtos = _mapper.Map<CostDto>(costs);

            return CreateActionResult(CustomResponseDto<CostDto>.Success(201, costDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CostDto costDto)
        {
            await _service.UpdateAsync(_mapper.Map<Cost>(costDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var cost = await _service.GetByIdAsync(id);

            cost.IsDeleted = true;

            await _service.UpdateAsync(cost);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
