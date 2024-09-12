using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorClassController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorClass> _service;
        public ErrorClassController(IMapper mapper, IService<ErrorClass> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorClass = await _service.GetAllAsync();
            var errorClassDto = _mapper.Map<List<ErrorClassDto>>(errorClass.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorClassDto>>.Success(200, errorClassDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorClass = await _service.GetByIdAsync(id);
            var errorClassDto = _mapper.Map<ErrorClassDto>(errorClass);
            return CreateActionResult(CustomResponseDto<ErrorClassDto>.Success(200, errorClassDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorClassDto errorClassDtos)
        {
            var errorClass = await _service.AddAsync(_mapper.Map<ErrorClass>(errorClassDtos));
            errorClass.IsDeleted = false;
            var errorClassDto = _mapper.Map<ErrorClassDto>(errorClass);

            return CreateActionResult(CustomResponseDto<ErrorClassDto>.Success(201, errorClassDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorClassDto errorClassDto)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorClass>(errorClassDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorClass = await _service.GetByIdAsync(id);

            errorClass.IsDeleted = true;

            await _service.UpdateAsync(errorClass);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
