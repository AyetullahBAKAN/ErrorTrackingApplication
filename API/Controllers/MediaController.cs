using AutoMapper;
using Core.DTOs;
using Core.IService;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class MediaController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Media> _service;

        public MediaController(IMapper mapper, IService<Media> service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var media = await _service.GetAllAsync();
            var mediaDto = _mapper.Map<List<MediaDto>>(media.ToList());

            return CreateActionResult(CustomResponseDto<List<MediaDto>>.Success(200, mediaDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var media = await _service.GetByIdAsync(id);
            var mediaDto = _mapper.Map<MediaDto>(media);
            return CreateActionResult(CustomResponseDto<MediaDto>.Success(200, mediaDto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(MediaDto mediaDtos)
        {
            var media = await _service.AddAsync(_mapper.Map<Media>(mediaDtos));
            media.IsDeleted = false;
            var mediaDto = _mapper.Map<MediaDto>(media);

            return CreateActionResult(CustomResponseDto<MediaDto>.Success(201, mediaDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(MediaDto mediaDto)
        {
            await _service.UpdateAsync(_mapper.Map<Media>(mediaDto));

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var media = await _service.GetByIdAsync(id);

            media.IsDeleted = true;

            await _service.UpdateAsync(media);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
