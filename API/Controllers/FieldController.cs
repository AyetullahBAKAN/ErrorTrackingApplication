using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class FieldController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Field> _service;

        public FieldController(IMapper mapper, IService<Field> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var field = await _service.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.ToList());

            return CreateActionResult(CustomResponseDto<List<FieldDto>>.Success(200, fieldDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var field = await _service.GetByIdAsync(id);
            var fieldDto = _mapper.Map<FieldDto>(field);
            return CreateActionResult(CustomResponseDto<FieldDto>.Success(200, fieldDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(FieldDto fieldDto)
        {
            var field = await _service.AddAsync(_mapper.Map<Field>(fieldDto));
            field.IsDeleted = false;
            var fieldDtos = _mapper.Map<FieldDto>(field);

            return CreateActionResult(CustomResponseDto<FieldDto>.Success(201, fieldDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(FieldDto fieldDto)
        {
            await _service.UpdateAsync(_mapper.Map<Field>(fieldDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var field = await _service.GetByIdAsync(id);

            field.IsDeleted = true;

            await _service.UpdateAsync(field);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
