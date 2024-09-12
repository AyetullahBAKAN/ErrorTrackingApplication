using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorDetectionLocationController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<ErrorDetectionLocation> _service;

        public ErrorDetectionLocationController(IMapper mapper, IService<ErrorDetectionLocation> service)
        {
            _mapper = mapper;
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var errorDetection = await _service.GetAllAsync();
            var errorDetectionDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorDetection.ToList());

            return CreateActionResult(CustomResponseDto<List<ErrorDetectionLocationDto>>.Success(200, errorDetectionDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var errorDetection = await _service.GetByIdAsync(id);
            var errorDetectionDto = _mapper.Map<ErrorDetectionLocationDto>(errorDetection);
            return CreateActionResult(CustomResponseDto<ErrorDetectionLocationDto>.Success(200, errorDetectionDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ErrorDetectionLocationDto errorDetectionLocationDto)
        {
            var errorDetection = await _service.AddAsync(_mapper.Map<ErrorDetectionLocation>(errorDetectionLocationDto));
            errorDetection.IsDeleted = false;
            var errorDetections = _mapper.Map<ErrorDetectionLocationDto>(errorDetection);

            return CreateActionResult(CustomResponseDto<ErrorDetectionLocationDto>.Success(201, errorDetections));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ErrorDetectionLocationDto errorDetectionLocationDto)
        {
            await _service.UpdateAsync(_mapper.Map<ErrorDetectionLocation>(errorDetectionLocationDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var errorDetectionLocation = await _service.GetByIdAsync(id);

            errorDetectionLocation.IsDeleted = true;

            await _service.UpdateAsync(errorDetectionLocation);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
