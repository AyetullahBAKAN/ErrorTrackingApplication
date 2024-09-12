using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class ErrorMainTitleController : Controller
    {
        private readonly ErrorMainTitleService _service;
        private readonly IMapper _mapper;

        public ErrorMainTitleController(ErrorMainTitleService errorMainTitleService, IMapper mapper)
        {
            _service = errorMainTitleService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorMainTitleAsync();
            if (result == null)
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorMainTitleList = await _service.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.ToList());

            return View(CustomResponseDto<List<ErrorMainTitleDto>>.Success(200, errorMainTitleListDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorMainTitleList = await _service.GetAllAsync();
            var errorMainTitleListDto = _mapper.Map<List<ErrorMainTitleDto>>(errorMainTitleList.Where(x => !x.IsDeleted));
            return View();
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorMainTitleDto errorMainTitleListDto)
        {

            var errorMainTitleList = await _service.AddAsync(_mapper.Map<ErrorMainTitle>(errorMainTitleListDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var errorMainTitleList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorMainTitleDto>(errorMainTitleList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorMainTitleDto errorMainTitleListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorMainTitle>(errorMainTitleListDto));

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> ShowErrorMainTitle(Guid id)
        {
            var errorMainTitleList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorMainTitleDto>(errorMainTitleList));
        }


        [HttpPost]
        public async Task<IActionResult> ShowErrorMainTitle(ErrorMainTitleDto errorMainTitleListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorMainTitle>(errorMainTitleListDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteErrorMainTitle(Guid id)
        {
            var errorMainTitleList = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorMainTitleDto>(errorMainTitleList));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteErrorMainTitle(ErrorMainTitleDto errorMainTitleListDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorMainTitle>(errorMainTitleListDto));

            return RedirectToAction(nameof(Index));

        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var errorMainTitleList = await _service.GetByIdAsync(id);
            errorMainTitleList.IsDeleted = true;
            await _service.UpdateAsync(errorMainTitleList);
            return RedirectToAction(nameof(Index));
        }
    }
}
