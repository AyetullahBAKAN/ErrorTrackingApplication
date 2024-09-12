using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class PartController : Controller
    {
        private readonly PartService _service;
        private readonly IMapper _mapper;
        public PartController(PartService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetPartListAsync();
            if (result == null || !result.Any())
                return BadRequest();

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var part = await _service.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(part.ToList());

            return View(CustomResponseDto<List<PartDto>>.Success(200, partDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var part = await _service.GetAllAsync();
            var partDto = _mapper.Map<List<PartDto>>(part.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(PartDto partDto)
        {

            var part = await _service.AddAsync(_mapper.Map<Part>(partDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var part = await _service.GetByIdAsync(id);

            return View(_mapper.Map<PartDto>(part));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(PartDto partDto)
        {

            await _service.UpdateAsync(_mapper.Map<Part>(partDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowPart(Guid id)
        {
            var part = await _service.GetByIdAsync(id);

            return View(_mapper.Map<PartDto>(part));
        }


        [HttpPost]
        public async Task<IActionResult> ShowPart(PartDto partDto)
        {

            await _service.UpdateAsync(_mapper.Map<Part>(partDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeletePart(Guid id)
        {
            var part = await _service.GetByIdAsync(id);

            return View(_mapper.Map<PartDto>(part));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeletePart(PartDto partDto)
        {

            await _service.UpdateAsync(_mapper.Map<Part>(partDto));

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var part = await _service.GetByIdAsync(id);
            part.IsDeleted = true;
            await _service.UpdateAsync(part);
            return RedirectToAction(nameof(Index));
        }

    }
}
