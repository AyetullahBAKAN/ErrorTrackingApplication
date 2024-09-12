using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class ErrorClosingReasonController : Controller
    {
        private readonly ErrorClosingReasonService _service;
        private readonly IMapper _mapper;
        public ErrorClosingReasonController(ErrorClosingReasonService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorClosingReasonListAsync();
            if (result == null)
                return BadRequest();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorClosingReason = await _service.GetAllAsync();
            var errorClosingReasonDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReason.ToList());

            return View(CustomResponseDto<List<ErrorClosingReasonDto>>.Success(200, errorClosingReasonDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorClosingReason = await _service.GetAllAsync();
            var errorClosingReasonDto = _mapper.Map<List<ErrorClosingReasonDto>>(errorClosingReason.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorClosingReasonDto errorClosingReasonDto)
        {

            var errorClosingReason = await _service.AddAsync(_mapper.Map<ErrorClosingReason>(errorClosingReasonDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var errorClosingReason = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorClosingReasonDto>(errorClosingReason));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorClosingReasonDto errorClosingReasonDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorClosingReason>(errorClosingReasonDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowReason(Guid id)
        {
            var errorClosingReason = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorClosingReasonDto>(errorClosingReason));
        }


        [HttpPost]
        public async Task<IActionResult> ShowReason(ErrorClosingReasonDto errorClosingReasonDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorClosingReason>(errorClosingReasonDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteReason(Guid id)
        {
            var errorClosingReason = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorClosingReasonDto>(errorClosingReason));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteReason(ErrorClosingReasonDto errorClosingReasonDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorClosingReason>(errorClosingReasonDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorClosingReason = await _service.GetByIdAsync(id);
            errorClosingReason.IsDeleted = true;
            await _service.UpdateAsync(errorClosingReason);
            return RedirectToAction(nameof(Index));
        }
    }
}
