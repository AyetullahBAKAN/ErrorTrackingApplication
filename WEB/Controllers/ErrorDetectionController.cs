using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class ErrorDetectionController : Controller
    {
        private readonly ErrorDetectionLocationService _service;
        private readonly IMapper _mapper;
        public ErrorDetectionController(ErrorDetectionLocationService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorDetectionListAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorDetectionLocation = await _service.GetAllAsync();
            var errorDetectionLocationDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorDetectionLocation.ToList());

            return View(CustomResponseDto<List<ErrorDetectionLocationDto>>.Success(200, errorDetectionLocationDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorDetectionLocation = await _service.GetAllAsync();
            var errorDetectionLocationDto = _mapper.Map<List<ErrorDetectionLocationDto>>(errorDetectionLocation.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorDetectionLocationDto errorDetectionLocationDto)
        {

            var errorDetectionLocation = await _service.AddAsync(_mapper.Map<ErrorDetectionLocation>(errorDetectionLocationDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var errorDetectionLocation = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDetectionLocationDto>(errorDetectionLocation));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorDetectionLocationDto errorDetectionLocationDto)
        {


            await _service.UpdateAsync(_mapper.Map<ErrorDetectionLocation>(errorDetectionLocationDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowErrorDetection(Guid id)
        {
            var errorDetectionLocation = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDetectionLocationDto>(errorDetectionLocation));
        }


        [HttpPost]
        public async Task<IActionResult> ShowErrorDetection(ErrorDetectionLocationDto errorDetectionLocationDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDetectionLocation>(errorDetectionLocationDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteErrorDetection(Guid id)
        {
            var errorDetectionLocation = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDetectionLocationDto>(errorDetectionLocation));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteErrorDetection(ErrorDetectionLocationDto errorDetectionLocationDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDetectionLocation>(errorDetectionLocationDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorDetectionLocation = await _service.GetByIdAsync(id);
            errorDetectionLocation.IsDeleted = true;
            await _service.UpdateAsync(errorDetectionLocation);
            return RedirectToAction(nameof(Index));
        }
    }
}
