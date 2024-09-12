using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class ErrorDefineController : Controller
    {
        private readonly ErrorDefineService _service;
        private readonly IMapper _mapper;
        public ErrorDefineController(ErrorDefineService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetErrorDefineListAsync();
            if (result == null )
                return BadRequest();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var errorDefine = await _service.GetAllAsync();
            var errorDefineDto = _mapper.Map<List<ErrorDefineDto>>(errorDefine.ToList());

            return View(CustomResponseDto<List<ErrorDefineDto>>.Success(200, errorDefineDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var errorDefine = await _service.GetAllAsync();
            var errorDefineDto = _mapper.Map<List<ErrorDefineDto>>(errorDefine.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(ErrorDefineDto errorDefineDto)
        {
            var errorDefine = await _service.AddAsync(_mapper.Map<ErrorDefine>(errorDefineDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var errorDefine = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDefineDto>(errorDefine));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(ErrorDefineDto errorDefineDto)
        {


            await _service.UpdateAsync(_mapper.Map<ErrorDefine>(errorDefineDto));

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> ShowErrorDefine(Guid id)
        {
            var errorDefine = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDefineDto>(errorDefine));
        }


        [HttpPost]
        public async Task<IActionResult> ShowErrorDefine(ErrorDefineDto errorDefineDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDefine>(errorDefineDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteErrorDefine(Guid id)
        {
            var errorDefine = await _service.GetByIdAsync(id);

            return View(_mapper.Map<ErrorDefineDto>(errorDefine));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteErrorDefine(ErrorDefineDto errorDefineDto)
        {

            await _service.UpdateAsync(_mapper.Map<ErrorDefine>(errorDefineDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var errorDefine = await _service.GetByIdAsync(id);
            errorDefine.IsDeleted = true;
            await _service.UpdateAsync(errorDefine);
            return RedirectToAction(nameof(Index));
        }
    }
}
