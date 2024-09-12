using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorDetailGroupController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorDetailGroup> _service;

        public ErrorDetailGroupController(IMapper mapper, IService<ErrorDetailGroup> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorDetailGroup = await _service.GetAllAsync();
            var errorDetailGroupDto = _mapper.Map<List<ErrorDetailGroupDto>>(errorDetailGroup.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorDetailGroupDto>>.Success(200, errorDetailGroupDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorDetailGroup = await _service.GetByIdAsync(id);
            var errorDetailGroupDto = _mapper.Map<ErrorDetailGroupDto>(errorDetailGroup);
            return CreateActionResult(CustomResponseDto<ErrorDetailGroupDto>.Success(200, errorDetailGroupDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorDetailGroupDto errorDetailGroupDtos)
        {
            var errorDetailGroup = await _service.AddAsync(_mapper.Map<ErrorDetailGroup>(errorDetailGroupDtos));
            errorDetailGroup.IsDeleted = false;
            var errorDetailGroupDto = _mapper.Map<ErrorDetailGroupDto>(errorDetailGroup);

            return CreateActionResult(CustomResponseDto<ErrorDetailGroupDto>.Success(201, errorDetailGroupDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ErrorDetailGroupDto errorDetailGroupDtos)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorDetailGroup>(errorDetailGroupDtos));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorDetailGroup = await _service.GetByIdAsync(id);

            errorDetailGroup.IsDeleted = true;

            await _service.UpdateAsync(errorDetailGroup);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
