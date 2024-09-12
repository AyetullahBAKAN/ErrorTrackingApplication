using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorTypeController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorType> _service;

        public ErrorTypeController(IMapper mapper, IService<ErrorType> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorType = await _service.GetAllAsync();
            var errorTypeDto = _mapper.Map<List<ErrorTypeDto>>(errorType.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorTypeDto>>.Success(200, errorTypeDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorType = await _service.GetByIdAsync(id);
            var errorTypeDto = _mapper.Map<ErrorTypeDto>(errorType);
            return CreateActionResult(CustomResponseDto<ErrorTypeDto>.Success(200, errorTypeDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorTypeDto errorTypeDtos)
        {
            var errorType = await _service.AddAsync(_mapper.Map<ErrorType>(errorTypeDtos));
            errorType.IsDeleted = false;
            var errorTypeDto = _mapper.Map<ErrorTypeDto>(errorType);

            return CreateActionResult(CustomResponseDto<ErrorTypeDto>.Success(201, errorTypeDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorTypeDto errorTypeDto)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorType>(errorTypeDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorType = await _service.GetByIdAsync(id);

            errorType.IsDeleted = true;

            await _service.UpdateAsync(errorType);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
