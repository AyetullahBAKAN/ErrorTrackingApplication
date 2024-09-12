using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorDefineController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorDefine> _service;
        public ErrorDefineController(IMapper mapper, IService<ErrorDefine> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorDefines = await _service.GetAllAsync();
            var errorDefineDtos = _mapper.Map<List<ErrorDefineDto>>(errorDefines.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorDefineDto>>.Success(200, errorDefineDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorDefines = await _service.GetByIdAsync(id);
            var errorDefineDtos = _mapper.Map<ErrorDefineDto>(errorDefines);
            return CreateActionResult(CustomResponseDto<ErrorDefineDto>.Success(200, errorDefineDtos));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorDefineDto errorDefineDto)
        {
            var errorDefines = await _service.AddAsync(_mapper.Map<ErrorDefine>(errorDefineDto));
            errorDefines.IsDeleted = false;
            var errorDefineDtos = _mapper.Map<ErrorDefineDto>(errorDefines);

            return CreateActionResult(CustomResponseDto<ErrorDefineDto>.Success(201, errorDefineDtos));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorDefineDto errorDefineDto)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorDefine>(errorDefineDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorDefine = await _service.GetByIdAsync(id);

            errorDefine.IsDeleted = true;

            await _service.UpdateAsync(errorDefine);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
