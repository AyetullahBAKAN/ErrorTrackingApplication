using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class MediaController : Controller
    {
        private readonly MediaService _service;
        private readonly IMapper _mapper;
        public MediaController(MediaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetMediaListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var mediaList = await _service.GetAllAsync();
            var mediaListDto = _mapper.Map<List<MediaDto>>(mediaList.ToList());

            return View(CustomResponseDto<List<MediaDto>>.Success(200, mediaListDto));
        }

        public async Task<IActionResult> Create()
        {
            var mediaList = await _service.GetAllAsync();
            var mediaListDto = _mapper.Map<List<MediaDto>>(mediaList.Where(x => !x.IsDeleted));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MediaDto mediaDto)
        {

            var mediaList = await _service.AddAsync(_mapper.Map<Media>(mediaDto));
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var mediaList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<MediaDto>(mediaList));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(MediaDto mediaDto)
        {


            await _service.UpdateAsync(_mapper.Map<Media>(mediaDto));

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> ShowMedia(Guid id)
        {
            var mediaList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<MediaDto>(mediaList));
        }


        [HttpPost]
        public async Task<IActionResult> ShowMedia(MediaDto mediaDto)
        {


            await _service.UpdateAsync(_mapper.Map<Media>(mediaDto));

            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var mediaList = await _service.GetByIdAsync(id);
            mediaList.IsDeleted = true;
            await _service.UpdateAsync(mediaList);
            return RedirectToAction(nameof(Index));
        }
    }
}
