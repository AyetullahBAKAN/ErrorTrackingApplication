using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class MontageLetterController : Controller
    {
        private readonly MontageLetterService _service;
        private readonly IMapper _mapper;
        public MontageLetterController(MontageLetterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetMontageLetterListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var montage = await _service.GetAllAsync();
            var montageDto = _mapper.Map<List<MontageLetterDto>>(montage.ToList());

            return View(CustomResponseDto<List<MontageLetterDto>>.Success(200, montageDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var montage = await _service.GetAllAsync();
            var montageDto = _mapper.Map<List<MontageLetterDto>>(montage.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(MontageLetterDto montageDto)
        {

            var montage = await _service.AddAsync(_mapper.Map<MontageLetter>(montageDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var montage = await _service.GetByIdAsync(id);

            return View(_mapper.Map<MontageLetterDto>(montage));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(MontageLetterDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<MontageLetter>(montageDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowMontageLetter(Guid id)
        {
            var montage = await _service.GetByIdAsync(id);

            return View(_mapper.Map<MontageLetterDto>(montage));
        }

        [HttpPost]
        public async Task<IActionResult> ShowMontageLetter(MontageLetterDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<MontageLetter>(montageDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteMontageLetter(Guid id)
        {
            var montage = await _service.GetByIdAsync(id);

            return View(_mapper.Map<MontageLetterDto>(montage));
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteMontageLetter(MontageLetterDto montageDto)
        {

            await _service.UpdateAsync(_mapper.Map<MontageLetter>(montageDto));

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var montage = await _service.GetByIdAsync(id);
            montage.IsDeleted = true;
            await _service.UpdateAsync(montage);
            return RedirectToAction(nameof(Index));
        }
    }
}
