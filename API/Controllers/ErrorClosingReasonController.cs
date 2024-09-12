using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorClosingReasonController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorClosingReason> _service;
        public ErrorClosingReasonController(IMapper mapper, IService<ErrorClosingReason> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorClosingReasons = await _service.GetAllAsync();
            var errorClosingReasonsDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReasons.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorClosingReasonDto>>.Success(200, errorClosingReasonsDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorClosingReasons = await _service.GetByIdAsync(id);
            var errorClosingReasonsDto = _mapper.Map<ErrorClosingReasonDto>(errorClosingReasons);
            return CreateActionResult(CustomResponseDto<ErrorClosingReasonDto>.Success(200, errorClosingReasonsDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorClosingReasonDto errorClosingReasonsDtos)
        {
            var errorClosingReasons = await _service.AddAsync(_mapper.Map<ErrorClosingReason>(errorClosingReasonsDtos));
            errorClosingReasons.IsDeleted = false;
            var errorClosingReasonsDto = _mapper.Map<ErrorClosingReasonDto>(errorClosingReasons);

            return CreateActionResult(CustomResponseDto<ErrorClosingReasonDto>.Success(201, errorClosingReasonsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorClosingReasonDto errorClosingReasonsDtos)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorClosingReason>(errorClosingReasonsDtos));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorClosingReasons = await _service.GetByIdAsync(id);

            errorClosingReasons.IsDeleted = true;

            await _service.UpdateAsync(errorClosingReasons);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
