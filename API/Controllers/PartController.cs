using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class PartController : CustomBaseController
    {
        private readonly IService<Part> _partService;
        private readonly IMapper _mapper;

        public PartController(IMapper mapper, IService<Part> partService)
        {
            _partService = partService;
            _mapper = mapper;
        }

        [HttpGet]

        public async Task<IActionResult> GetPart()
        {
            var part = await _partService.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(part.ToList());
            return CreateActionResult(CustomResponseDto<List<PartDto>>.Success(200, partDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var part = await _partService.GetByIdAsync(id);
            var partDto = _mapper.Map<PartDto>(part);
            return CreateActionResult(CustomResponseDto<PartDto>.Success(200, partDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PartDto partDto)
        {
            var parts = await _partService.AddAsync(_mapper.Map<Part>(partDto));
            parts.IsDeleted = false;
            var partDtos = _mapper.Map<PartDto>(parts);

            return CreateActionResult(CustomResponseDto<PartDto>.Success(201, partDtos));
        }


        [HttpPut]
        public async Task<IActionResult> Update(PartDto partDto)
        {
            await _partService.UpdateAsync(_mapper.Map<Part>(partDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var part = await _partService.GetByIdAsync(id);
            part.IsDeleted = true;

            await _partService.UpdateAsync(part);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}