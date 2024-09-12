using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class UnitController : CustomBaseController
    {
        private readonly IService<Unit> _service;
        private readonly IMapper _mapper;

        public UnitController(IService<Unit> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var unit = await _service.GetAllAsync();
            var unitDto = _mapper.Map<List<UnitDto>>(unit.ToList());

            return CreateActionResult(CustomResponseDto<List<UnitDto>>.Success(200, unitDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var unit = await _service.GetByIdAsync(id);
            var unitDto = _mapper.Map<UnitDto>(unit);
            return CreateActionResult(CustomResponseDto<UnitDto>.Success(200, unitDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(UnitDto unitDto)
        {
            var unit = await _service.AddAsync(_mapper.Map<Unit>(unitDto));
            unit.IsDeleted = false;
            var unitDtos = _mapper.Map<UnitDto>(unit);

            return CreateActionResult(CustomResponseDto<UnitDto>.Success(201, unitDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(UnitDto unitDto)
        {
            await _service.UpdateAsync(_mapper.Map<Unit>(unitDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var unit = await _service.GetByIdAsync(id);

            unit.IsDeleted = true;

            await _service.UpdateAsync(unit);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
