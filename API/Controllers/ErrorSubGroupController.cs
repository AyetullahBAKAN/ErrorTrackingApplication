using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ErrorSubGroupController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorSubGroup> _service;

        public ErrorSubGroupController(IMapper mapper, IService<ErrorSubGroup> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorSubGroup = await _service.GetAllAsync();
            var errorSubGroupDto = _mapper.Map<List<ErrorSubGroupDto>>(errorSubGroup.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorSubGroupDto>>.Success(200, errorSubGroupDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorSubGroup = await _service.GetByIdAsync(id);
            var errorSubGroupDto = _mapper.Map<ErrorSubGroupDto>(errorSubGroup);
            return CreateActionResult(CustomResponseDto<ErrorSubGroupDto>.Success(200, errorSubGroupDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorSubGroupDto errorSubGroups)
        {
            var errorSubGroup = await _service.AddAsync(_mapper.Map<ErrorSubGroup>(errorSubGroups));
            errorSubGroup.IsDeleted = false;
            var errorSubGroupDto = _mapper.Map<ErrorSubGroupDto>(errorSubGroup);

            return CreateActionResult(CustomResponseDto<ErrorSubGroupDto>.Success(201, errorSubGroupDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorSubGroupDto errorSubGroups)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorSubGroup>(errorSubGroups));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorSubGroup = await _service.GetByIdAsync(id);

            errorSubGroup.IsDeleted = true;

            await _service.UpdateAsync(errorSubGroup);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
