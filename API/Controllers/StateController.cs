using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class StateController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<State> _service;

        public StateController(IMapper mapper, IService<State> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var state = await _service.GetAllAsync();
            var stateDto = _mapper.Map<List<StateDto>>(state.ToList());

            return CreateActionResult(CustomResponseDto<List<StateDto>>.Success(200, stateDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var state = await _service.GetByIdAsync(id);
            var stateDto = _mapper.Map<StateDto>(state);
            return CreateActionResult(CustomResponseDto<StateDto>.Success(200, stateDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(StateDto stateDto)
        {
            var state = await _service.AddAsync(_mapper.Map<State>(stateDto));
            state.IsDeleted = false;
            var stateDtos = _mapper.Map<StateDto>(state);

            return CreateActionResult(CustomResponseDto<StateDto>.Success(201, stateDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(StateDto unitDto)
        {
            await _service.UpdateAsync(_mapper.Map<State>(unitDto));

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
