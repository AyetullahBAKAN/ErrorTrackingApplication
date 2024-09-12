using AutoMapper;
using Core.DTOs;
using Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Service;

namespace WEB.Controllers
{
	[Authorize]

	public class FieldController : Controller
    {
        private readonly FieldService _service;
        private readonly IMapper _mapper;
        public FieldController(FieldService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetFieldListAsync();
            if (result == null )
                return BadRequest();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var field = await _service.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.ToList());

            return View(CustomResponseDto<List<FieldDto>>.Success(200, fieldDto));
        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Create()
        {
            var field = await _service.GetAllAsync();
            var fieldDto = _mapper.Map<List<FieldDto>>(field.Where(x => !x.IsDeleted));
            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Create(FieldDto fieldDto)
        {

            var field = await _service.AddAsync(_mapper.Map<Field>(fieldDto));
            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Edit(Guid id)
        {
            var field = await _service.GetByIdAsync(id);

            return View(_mapper.Map<FieldDto>(field));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> Edit(FieldDto fieldDto)
        {

            await _service.UpdateAsync(_mapper.Map<Field>(fieldDto));

            return RedirectToAction(nameof(Index));

        }


        public async Task<IActionResult> ShowField(Guid id)
        {
            var field = await _service.GetByIdAsync(id);

            return View(_mapper.Map<FieldDto>(field));
        }


        [HttpPost]
        public async Task<IActionResult> ShowField(FieldDto fieldDto)
        {

            await _service.UpdateAsync(_mapper.Map<Field>(fieldDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> DeleteField(Guid id)
        {
            var field = await _service.GetByIdAsync(id);

            return View(_mapper.Map<FieldDto>(field));
        }

        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> DeleteField(FieldDto fieldDto)
        {

            await _service.UpdateAsync(_mapper.Map<Field>(fieldDto));

            return RedirectToAction(nameof(Index));

        }
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(Guid id)
        {
            var field = await _service.GetByIdAsync(id);
            field.IsDeleted = true;
            await _service.UpdateAsync(field);
            return RedirectToAction(nameof(Index));
        }
    }
}
